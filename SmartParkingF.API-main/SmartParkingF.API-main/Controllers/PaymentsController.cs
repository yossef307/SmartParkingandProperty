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
                    Id = r.Id,
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

        [HttpPost("Process")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDTO request)
        {
            if (request == null) return BadRequest("بيانات الدفع غير مكتملة");

            try
            {
                var newReservation = new Reservation
                {
                    UserId = request.UserId,
                    PropertyId = request.PropertyId,

                    // التعديل: إذا لم يوجد موقف، نرسل null بدلاً من 0 لتجنب خطأ الـ Foreign Key
                    ParkingSpotId = request.ParkingSpotId > 0 ? request.ParkingSpotId : null,

                    TotalPrice = request.Amount,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(1),
                    Status = "Confirmed"
                    // ملاحظة: إذا كان الـ Model يتطلب حقولاً أخرى (مثل CreatedAt)، أضفها هنا
                };

                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "تم تأكيد الحجز والدفع بنجاح",
                    TransactionId = "TXN-" + newReservation.Id.ToString().PadLeft(6, '0')
                });
            }
            catch (DbUpdateException dbEx)
            {
                // هذا الجزء سيكشف لنا السبب الحقيقي في الـ Console أو الـ Response
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                return StatusCode(500, $"خطأ في قاعدة البيانات: {innerMessage}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"حدث خطأ عام: {ex.Message}");
            }
        }
    }

    public class PaymentRequestDTO
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public required string Method { get; set; }
        public int PropertyId { get; set; }
        public int? ParkingSpotId { get; set; }
    }
}