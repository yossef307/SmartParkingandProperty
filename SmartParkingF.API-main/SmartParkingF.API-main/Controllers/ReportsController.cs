using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
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
                // 1. حساب إجمالي الإيرادات من الحجوزات (Reservations)
                var reservationsRevenue = await _context.Reservations
                    .Where(r => r.Status == "Confirmed" || r.Status == "Completed")
                    .SumAsync(r => r.TotalPrice);

                // 2. حساب إجمالي الإيرادات من المبيعات (Sales)
                var salesRevenue = await _context.Sales
                    .Where(s => s.Status == "Completed")
                    .SumAsync(s => s.SalePrice);

                // 3. إجمالي الإيرادات الكلي
                var totalRevenue = reservationsRevenue + salesRevenue;

                // 4. حساب عدد الحجوزات الكلي
                var totalBookings = await _context.Reservations.CountAsync();

                // 5. حساب عدد المبيعات الكلي
                var totalSales = await _context.Sales.CountAsync();

                // 6. حساب عدد الأماكن المشغولة حالياً
                var now = DateTime.Now;
                var occupiedSpots = await _context.Reservations
                    .Where(r => r.Status == "Confirmed" && r.StartTime <= now && r.EndTime >= now)
                    .Select(r => r.ParkingSpotId)
                    .Distinct()
                    .CountAsync();
                var totalSpots = await _context.ParkingSpots.CountAsync();

                // 7. جلب آخر المعاملات (حجوزات + مبيعات)
                var reservationTransactions = await _context.Reservations
                    .Include(r => r.Property)
                    .Include(r => r.ParkingSpot)
                    .OrderByDescending(r => r.CreatedAt)
                    .Take(5)
                    .Select(r => new {
                        PropertyName = r.Property != null ? r.Property.Name : "Unknown",
                        SpotNumber = r.ParkingSpot != null ? r.ParkingSpot.SpotNumber : "N/A",
                        Date = r.CreatedAt.ToString("MMM dd, yyyy"),
                        Amount = r.TotalPrice,
                        Status = r.Status,
                        Type = "Parking"
                    })
                    .ToListAsync();

                var saleTransactions = await _context.Sales
                    .Include(s => s.Property)
                    .Include(s => s.Buyer)
                    .OrderByDescending(s => s.CreatedAt)
                    .Take(5)
                    .Select(s => new {
                        PropertyName = s.Property != null ? s.Property.Name : "Unknown",
                        SpotNumber = "Sale",
                        Date = s.CreatedAt.ToString("MMM dd, yyyy"),
                        Amount = s.SalePrice,
                        Status = s.Status,
                        Type = "Sale"
                    })
                    .ToListAsync();

                // دمج المعاملات وترتيبها
                var allTransactions = reservationTransactions
                    .Concat(saleTransactions)
                    .OrderByDescending(t => t.Date)
                    .Take(10)
                    .ToList();

                // 8. حساب نسبة الإيرادات من كل نوع
                var totalRevenueForPercentage = totalRevenue > 0 ? totalRevenue : 1;
                var salesPercentage = Math.Round((salesRevenue / totalRevenueForPercentage) * 100, 1);
                var parkingPercentage = Math.Round((reservationsRevenue / totalRevenueForPercentage) * 100, 1);

                return Ok(new
                {
                    TotalRevenue = totalRevenue,
                    ReservationsRevenue = reservationsRevenue,
                    SalesRevenue = salesRevenue,
                    TotalBookings = totalBookings,
                    TotalSales = totalSales,
                    ActiveSpots = $"{occupiedSpots}/{totalSpots}",
                    OccupiedSpots = occupiedSpots,
                    TotalSpots = totalSpots,
                    RecentTransactions = allTransactions,
                    RevenueBreakdown = new
                    {
                        SalesPercentage = salesPercentage,
                        ParkingPercentage = parkingPercentage
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error calculating reports", error = ex.Message });
            }
        }
    }
}
