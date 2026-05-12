using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. جلب تاريخ المدفوعات بناءً على سجل الحجوزات
        [HttpGet("user-history/{userId}")]
        public async Task<IActionResult> GetUserPaymentHistory(int userId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists) return NotFound("المستخدم غير موجود");

            var history = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.StartTime)
                .Select(r => new {
                    TransactionId = "TXN-" + r.Id.ToString().PadLeft(6, '0'),
                    Date = r.StartTime.ToString("MMM dd, yyyy"),
                    Method = "Visa .... 4242",
                    Status = r.Status,
                    Amount = r.TotalPrice,
                    PropertyName = r.Property != null ? r.Property.Name : "Smart Parking"
                })
                .ToListAsync();

            return Ok(history);
        }

        // 2. معالجة الدفع وإنشاء الحجز فعلياً في قاعدة البيانات
        [HttpPost("Process")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDTO request)
        {
            if (request == null) return BadRequest("بيانات الدفع غير مكتملة");

            try
            {
                // إنشاء سجل حجز جديد
                var newReservation = new Reservation
                {
                    UserId = request.UserId,
                    PropertyId = request.PropertyId,

                    // ✅ حل مشكلة الـ Casting:
                    // إذا كان الـ ParkingSpotId يحتوي على قيمة، نأخذها، وإذا كان Null نضع القيمة 0 (أو اتركها كما يتطلب منطق الـ Database عندك)
                    ParkingSpotId = request.ParkingSpotId.HasValue ? request.ParkingSpotId.Value : 0,

                    TotalPrice = request.Amount,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(1),
                    Status = "Confirmed"
                };

                // إضافة السجل لقاعدة البيانات
                _context.Reservations.Add(newReservation);

                // حفظ التغييرات نهائياً
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "تم تأكيد الحجز والدفع بنجاح",
                    TransactionId = "TXN-" + newReservation.Id.ToString().PadLeft(6, '0')
                });
            }
            catch (Exception ex)
            {
                // إرجاع تفاصيل الخطأ للمساعدة في التصحيح
                return StatusCode(500, $"حدث خطأ فني أثناء الحفظ: {ex.Message}");
            }
        }
    }

    // الـ DTO المستخدم لنقل البيانات من React
    public class PaymentRequestDTO
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public required string Method { get; set; }
        public int PropertyId { get; set; }
        public int? ParkingSpotId { get; set; } // يقبل Null هنا
    }
}