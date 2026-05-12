using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data; // المسار الصحيح للـ Data بناءً على الكود الخاص بك
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("financial-summary")]
        public async Task<IActionResult> GetFinancialSummary()
        {
            try
            {
                // 1. حساب إجمالي الإيرادات من حقل TotalPrice في جدول Reservations
                var totalRevenue = await _context.Reservations.SumAsync(r => r.TotalPrice);

                // 2. حساب عدد الحجوزات الكلي
                var totalBookings = await _context.Reservations.CountAsync();

                // 3. حساب عدد الأماكن المشغولة حالياً (بناءً على الـ Status في ParkingSpots)
                var occupiedSpots = await _context.ParkingSpots.CountAsync(s => s.Status == "Occupied");
                var totalSpots = await _context.ParkingSpots.CountAsync();

                // 4. جلب آخر 5 عمليات حجز لعرضها في جدول المعاملات
                var transactions = await _context.Reservations
                    .Include(r => r.Property)
                    .Include(r => r.ParkingSpot)
                    .OrderByDescending(r => r.Id) // الترتيب من الأحدث للأقدم
                    .Take(5)
                    .Select(r => new {
                        PropertyName = r.Property.Name, // استخدام Name كما هو معرف في الـ Context الخاص بك
                        SpotNumber = r.ParkingSpot.SpotNumber,
                        Date = DateTime.Now.ToString("MMM dd, yyyy"), // يمكنك استبدالها بتاريخ الحجز إذا كان متوفراً في الموديل
                        Amount = r.TotalPrice,
                        Status = "Completed"
                    })
                    .ToListAsync();

                return Ok(new
                {
                    TotalRevenue = totalRevenue,
                    TotalBookings = totalBookings,
                    ActiveSpots = $"{occupiedSpots}/{totalSpots}",
                    RecentTransactions = transactions
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error calculating reports", error = ex.Message });
            }
        }
    }
}