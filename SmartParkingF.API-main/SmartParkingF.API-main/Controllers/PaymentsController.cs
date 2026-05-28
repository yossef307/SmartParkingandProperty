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

            // 1. جلب حجوزات الباركينج
            var reservationHistory = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.StartTime)
                .Select(r => new {
                    Id = r.Id,
                    TransactionId = "TXN-" + r.Id.ToString().PadLeft(6, '0'),
                    Date = r.CreatedAt.ToString("MMM dd, yyyy"),
                    Method = "Credit Card (Visa .... 4242)",
                    Status = r.Status,
                    Amount = r.TotalPrice,
                    PropertyName = r.Property != null ? r.Property.Name : "Smart Parking",
                    Type = "Parking Booking"
                })
                .ToListAsync();

            // 2. جلب مشتريات العقارات (Sales)
            var salesHistory = await _context.Sales
                .Include(s => s.Property)
                .Where(s => s.BuyerId == userId)
                .OrderByDescending(s => s.CreatedAt)
                .Select(s => new {
                    Id = s.Id,
                    TransactionId = "SALE-" + s.Id.ToString().PadLeft(6, '0'),
                    Date = s.CreatedAt.ToString("MMM dd, yyyy"),
                    Method = s.PaymentMethod ?? "Credit Card (Visa .... 4242)",
                    Status = s.Status,
                    Amount = s.SalePrice,
                    PropertyName = s.Property != null ? s.Property.Name : "Property Purchase",
                    Type = "Property Purchase"
                })
                .ToListAsync();

            // 3. دمج كل المعاملات وترتيبها من الأحدث للأقدم
            var allHistory = reservationHistory
                .Select(r => new {
                    r.Id,
                    r.TransactionId,
                    r.Date,
                    r.Method,
                    r.Status,
                    r.Amount,
                    r.PropertyName,
                    r.Type
                })
                .Concat(salesHistory.Select(s => new {
                    s.Id,
                    s.TransactionId,
                    s.Date,
                    s.Method,
                    s.Status,
                    s.Amount,
                    s.PropertyName,
                    s.Type
                }))
                .OrderByDescending(t => t.Date)
                .ToList();

            return Ok(allHistory);
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
                    ParkingSpotId = request.ParkingSpotId > 0 ? request.ParkingSpotId : null,
                    TotalPrice = request.Amount,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(1),
                    Status = "Confirmed"
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