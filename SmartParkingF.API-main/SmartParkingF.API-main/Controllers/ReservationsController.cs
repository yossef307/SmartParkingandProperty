using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;
using System.Diagnostics;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. جلب كافة الحجوزات (محسن للأداء)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetReservations()
        {
            // نرجع object محدد لتجنب مشاكل الـ JSON المفرط
            return await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new {
                    r.Id,
                    r.StartTime,
                    r.EndTime,
                    r.TotalPrice,
                    r.Status,
                    r.QrCodeData,
                    r.CreatedAt,
                    SpotNumber = r.ParkingSpot.SpotNumber,
                    PropertyName = r.Property.Name,
                    UserEmail = r.User.Email
                })
                .AsNoTracking()
                .ToListAsync();
        }

        // 2. إنشاء حجز جديد (مع معالجة الأخطاء المتقدمة)
        [HttpPost]
        public async Task<ActionResult> PostReservation([FromBody] ReservationDto reservationDto)
        {
            if (reservationDto == null)
                return BadRequest(new { message = "بيانات الحجز غير مكتملة." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // التحقق المنطقي من التواريخ
            if (reservationDto.EndDate <= reservationDto.StartDate)
                return BadRequest(new { message = "يجب أن يكون وقت المغادرة بعد وقت الوصول." });

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // أ. التحقق من وجود السجلات المرتبطة (تأكد أن الـ IDs صحيحة في قاعدة البيانات)
                var spot = await _context.ParkingSpots.FindAsync(reservationDto.ParkingSpotId);
                var property = await _context.Properties.FindAsync(reservationDto.PropertyId);
                var user = await _context.Users.FindAsync(reservationDto.UserId);

                if (spot == null) return NotFound(new { message = "فشل: مكان الركن المحدد غير موجود." });
                if (property == null) return NotFound(new { message = "فشل: العقار المرتبط غير موجود." });
                if (user == null) return NotFound(new { message = "فشل: المستخدم غير موجود." });

                // ب. التحقق من حالة الركنة (منع الحجز المزدوج)
                if (spot.Status?.Trim().ToLower() != "available")
                {
                    return BadRequest(new { message = "عذراً، هذا المكان تم حجزه للتو أو غير متاح." });
                }

                // ج. بناء كائن الحجز
                var reservation = new Reservation
                {
                    PropertyId = reservationDto.PropertyId,
                    ParkingSpotId = reservationDto.ParkingSpotId,
                    UserId = reservationDto.UserId,
                    StartTime = reservationDto.StartDate,
                    EndTime = reservationDto.EndDate,
                    TotalPrice = reservationDto.TotalPrice,
                    // توليد كود QR فريد واحترافي
                    QrCodeData = $"RP-{reservationDto.UserId}-{DateTime.Now.Ticks.ToString().Substring(10)}",
                    Status = "Confirmed",
                    CreatedAt = DateTime.Now,
                    CarPlateNumber = "N/A", // يمكن تحديثها لاحقاً
                    BookingType = "Digital-Order"
                };

                // د. تحديث حالة المكان إلى "Busy"
                spot.Status = "Busy";

                _context.Reservations.Add(reservation);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new
                {
                    success = true,
                    message = "تم تأكيد حجزك بنجاح، البوابة بانتظارك.",
                    data = new
                    {
                        reservationId = reservation.Id,
                        qrCode = reservation.QrCodeData,
                        spotNumber = spot.SpotNumber
                    }
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                // تسجيل الخطأ للمطور
                var detailedError = ex.InnerException?.Message ?? ex.Message;
                Debug.WriteLine($"CRITICAL DATABASE ERROR: {detailedError}");

                return StatusCode(500, new
                {
                    message = "حدث خطأ فني أثناء الحفظ في قاعدة البيانات.",
                    error = detailedError
                });
            }
        }

        // 3. إلغاء الحجز (مع إعادة تعيين حالة الركنة)
        [HttpDelete("CancelBySpot/{spotId}")]
        public async Task<IActionResult> CancelBySpot(int spotId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // البحث عن الحجز المؤكد المرتبط بهذه الركنة
                var reservation = await _context.Reservations
                    .Where(r => r.ParkingSpotId == spotId && r.Status == "Confirmed")
                    .OrderByDescending(r => r.CreatedAt)
                    .FirstOrDefaultAsync();

                if (reservation == null)
                    return NotFound(new { message = "لم يتم العثور على حجز نشط لهذه الركنة." });

                // إعادة الركنة متاحة
                var spot = await _context.ParkingSpots.FindAsync(spotId);
                if (spot != null)
                {
                    spot.Status = "Available";
                }

                // تحديث حالة الحجز
                reservation.Status = "Cancelled";

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { success = true, message = "تم إلغاء الحجز بنجاح وإتاحة الركنة مرة أخرى." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(new { message = "فشل في عملية الإلغاء.", error = ex.Message });
            }
        }
    }
}