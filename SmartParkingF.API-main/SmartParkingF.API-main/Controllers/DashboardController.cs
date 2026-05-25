using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Stats")]
        public async Task<IActionResult> GetStats()
        {
            // إجمالي الإيرادات من الحجوزات المؤكدة بناءً على TotalPrice
            var totalRevenue = await _context.Reservations
                .Where(r => r.Status == "Confirmed")
                .SumAsync(r => r.TotalPrice);

            var activeReservations = await _context.Reservations
                .CountAsync(r => r.Status == "Confirmed");

            var totalSpots = await _context.ParkingSpots.CountAsync();
            var busySpots = await _context.ParkingSpots.CountAsync(s => s.Status == "Busy");

            return Ok(new
            {
                revenue = totalRevenue,
                activeReservations = activeReservations,
                totalSpots = totalSpots,
                availableSpots = totalSpots - busySpots,
                busySpots = busySpots,
                totalUsers = await _context.Users.CountAsync()
            });
        }

        [HttpGet("RecentReservations")]
        public async Task<IActionResult> GetRecentReservations()
        {
            var recent = await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Property)
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .Select(r => new
                {
                    id = r.Id,
                    // حل مشكلة UserName: استخدام Email بدلاً من UserName
                    userName = r.User != null ? (r.User.Email ?? "User") : "Unknown",
                    propertyName = r.Property != null ? r.Property.Name : "N/A",
                    totalPrice = r.TotalPrice,
                    status = r.Status,
                    date = r.StartTime
                })
                .ToListAsync();

            return Ok(recent);
        }
    }
}