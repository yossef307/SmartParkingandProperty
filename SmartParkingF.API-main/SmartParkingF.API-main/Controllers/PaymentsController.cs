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

        [HttpGet("user-history")]
        public async Task<IActionResult> GetUserPaymentHistory()
        {
            // 1. جلب أول مستخدم تجريبي لعرض بياناته
            var user = await _context.Users.FirstOrDefaultAsync();
            if (user == null) return NotFound("المستخدم غير موجود");

            // 2. جلب تاريخ المدفوعات بناءً على الحجوزات
            // استخدمنا Include لجلب بيانات الركنة والفيلا مع الحجز
            var history = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .Where(r => r.UserEmail == user.Email)
                .OrderByDescending(r => r.StartTime)
                .Select(r => new {
                    TransactionId = "TXN-" + r.Id.ToString().PadLeft(6, '0'),
                    Date = r.StartTime.ToString("MMM dd, yyyy"),
                    Method = "Visa .... 4242", // قيمة ثابتة للعرض حالياً
                    Status = r.Status,

                    // ✅ التعديل الجوهري: استخدام TotalPrice بدل Amount
                    Amount = r.TotalPrice,

                    // عرض اسم الفيلا ورقم الركنة معاً بشكل منسق
                    Description = (r.Property != null ? r.Property.Name : "Smart Parking") +
                                  " - Spot: " + (r.ParkingSpot != null ? r.ParkingSpot.SpotNumber : "N/A")
                })
                .ToListAsync();

            return Ok(history);
        }
    }
}