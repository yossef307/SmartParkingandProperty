using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;   // المسار الصحيح بناءً على مجلد Data
using SmartParkingF.API.Models; // المسار الصحيح بناءً على مجلد Models

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor لربط قاعدة البيانات
        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. جلب كل الحجوزات مع تفاصيل العقار والركنة والمستخدم
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        // 2. إنشاء حجز جديد (يتضمن Transaction لضمان سلامة البيانات)
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation([FromBody] ReservationDto reservationDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // استخدام Transaction لضمان تنفيذ كل الخطوات أو تراجعها بالكامل
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var spot = await _context.ParkingSpots.FindAsync(reservationDto.ParkingSpotId);
                var property = await _context.Properties.FindAsync(reservationDto.PropertyId);
                var userExists = await _context.Users.AnyAsync(u => u.Id == reservationDto.UserId);

                if (spot == null || property == null || !userExists)
                {
                    return NotFound(new { message = "المعلومات المقدمة (عقار، ركنة، أو مستخدم) غير موجودة." });
                }

                // التحقق من أن الركنة متاحة (Available)
                if (spot.Status?.Trim().ToLower() != "available")
                {
                    return BadRequest(new { message = "عذراً، هذا المكان لم يعد متاحاً حالياً." });
                }

                var reservation = new Reservation
                {
                    PropertyId = reservationDto.PropertyId,
                    ParkingSpotId = reservationDto.ParkingSpotId,
                    UserId = reservationDto.UserId,
                    StartTime = reservationDto.StartDate,
                    EndTime = reservationDto.EndDate,
                    TotalPrice = reservationDto.TotalPrice,
                    // إنشاء QR Code فريد للمشروع
                    QrCodeData = $"REALPARK-{reservationDto.UserId}-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}",
                    Status = "Confirmed",
                    CreatedAt = DateTime.Now
                };

                // تحديث حالة الركنة إلى Busy لضمان عدم حجزها مرتين
                spot.Status = "Busy";

                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();

                // إتمام العملية بنجاح في قاعدة البيانات
                await transaction.CommitAsync();

                return Ok(new
                {
                    success = true,
                    message = "تم تأكيد الحجز بنجاح وتحديث حالة الركنة",
                    data = reservation
                });
            }
            catch (Exception ex)
            {
                // في حال حدوث أي خطأ، يتم التراجع عن كل التغييرات
                await transaction.RollbackAsync();
                return StatusCode(500, new { message = "حدث خطأ داخلي أثناء معالجة الحجز", error = ex.Message });
            }
        }

        // 3. إلغاء الحجز بناءً على رقم الركنة (إعادة المكان متاحاً)
        [HttpDelete("CancelBySpot/{spotId}")]
        public async Task<IActionResult> CancelBySpot(int spotId)
        {
            var reservation = await _context.Reservations
                .Where(r => r.ParkingSpotId == spotId && r.Status == "Confirmed")
                .OrderByDescending(r => r.CreatedAt)
                .FirstOrDefaultAsync();

            if (reservation == null)
            {
                return NotFound(new { message = "لا يوجد حجز نشط لهذه الركنة حالياً." });
            }

            var spot = await _context.ParkingSpots.FindAsync(spotId);
            if (spot != null)
            {
                spot.Status = "Available"; // إعادة المكان متاحاً
            }

            reservation.Status = "Cancelled";

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "تم إلغاء الحجز بنجاح وإعادة توفر المكان." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "فشل إلغاء الحجز", error = ex.Message });
            }
        }

        // 4. جلب حجز معين بواسطة المعرف (ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null) return NotFound();

            return reservation;
        }
    }
}