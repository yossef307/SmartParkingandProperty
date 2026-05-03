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
            var history = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                // ✅ التعديل هنا: الفلترة باستخدام UserId بدلاً من UserEmail لضمان الدقة والأداء
                .Where(r => r.UserId == user.Id)
                .OrderByDescending(r => r.StartTime)
                .Select(r => new {
                    TransactionId = "TXN-" + r.Id.ToString().PadLeft(6, '0'),
                    Date = r.StartTime.ToString("MMM dd, yyyy"),
                    Method = "Visa .... 4242",
                    Status = r.Status,

                    // استخدام TotalPrice كما في الموديل الجديد
                    Amount = r.TotalPrice,

                    Description = (r.Property != null ? r.Property.Name : "Smart Parking") +
                                  " - Spot: " + (r.ParkingSpot != null ? r.ParkingSpot.SpotNumber : "N/A")
                })
                .ToListAsync();

            return Ok(history);
        }
    }
}