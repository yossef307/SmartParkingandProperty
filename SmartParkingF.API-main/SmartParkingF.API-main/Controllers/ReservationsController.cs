using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetReservations()
        {
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
                    SpotNumber = r.ParkingSpot != null ? r.ParkingSpot.SpotNumber : "N/A",
                    PropertyName = r.Property != null ? r.Property.Name : "N/A",
                    UserEmail = r.User != null ? r.User.Email : "N/A"
                })
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserReservations(int userId)
        {
            var reservations = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new {
                    r.Id,
                    r.StartTime,
                    r.EndTime,
                    r.TotalPrice,
                    r.Status,
                    r.QrCodeData,
                    r.CreatedAt,
                    ParkingSpotId = r.ParkingSpotId,
                    SpotNumber = r.ParkingSpot != null ? r.ParkingSpot.SpotNumber : "N/A",
                    PropertyId = r.PropertyId,
                    PropertyName = r.Property != null ? r.Property.Name : "N/A",
                    PropertyLocation = r.Property != null ? r.Property.Location : "N/A"
                })
                .AsNoTracking()
                .ToListAsync();

            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetReservation(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .Include(r => r.Property)
                .Include(r => r.User)
                .Where(r => r.Id == id)
                .Select(r => new {
                    r.Id,
                    r.StartTime,
                    r.EndTime,
                    r.TotalPrice,
                    r.Status,
                    r.QrCodeData,
                    r.CreatedAt,
                    r.CarPlateNumber,
                    r.BookingType,
                    ParkingSpotId = r.ParkingSpotId,
                    SpotNumber = r.ParkingSpot != null ? r.ParkingSpot.SpotNumber : "N/A",
                    PropertyId = r.PropertyId,
                    PropertyName = r.Property != null ? r.Property.Name : "N/A",
                    PropertyLocation = r.Property != null ? r.Property.Location : "N/A",
                    UserId = r.UserId,
                    UserEmail = r.User != null ? r.User.Email : "N/A",
                    UserName = r.User != null ? r.User.FullName : "N/A"
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (reservation == null) return NotFound(new { message = "Reservation not found." });
            return Ok(reservation);
        }

        [HttpGet("PropertyBookedDates/{propertyId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetPropertyBookedDates(int propertyId)
        {
            var bookedDates = await _context.Reservations
                .Where(r => r.PropertyId == propertyId && r.Status == "Confirmed")
                .Select(r => new
                {
                    r.Id,
                    r.StartTime,
                    r.EndTime
                })
                .AsNoTracking()
                .ToListAsync();

            return Ok(bookedDates);
        }

        [HttpPost]
        public async Task<ActionResult> PostReservation([FromBody] ReservationDto reservationDto)
        {
            if (reservationDto == null) return BadRequest(new { message = "Reservation data is incomplete." });
            if (!ModelState.IsValid) return BadRequest(ModelState);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var spot = await _context.ParkingSpots.FindAsync(reservationDto.ParkingSpotId);
                var property = await _context.Properties.FindAsync(reservationDto.PropertyId);

                // التحقق من تعارض حجوزات الـ Parking Spot فقط (وليس الـ Property بالكامل)
                if (reservationDto.ParkingSpotId != null && reservationDto.ParkingSpotId > 0)
                {
                    bool isSpotOccupied = await _context.Reservations
                        .AnyAsync(r => r.ParkingSpotId == reservationDto.ParkingSpotId &&
                                       r.Status == "Confirmed" &&
                                       reservationDto.StartDate < r.EndTime &&
                                       reservationDto.EndDate > r.StartTime);

                    if (isSpotOccupied)
                        return BadRequest(new { success = false, message = "مكان الباركينج محجوز بالفعل في الفترة المحددة." });
                }
                else
                {
                    // لو مفيش ParkingSpot (حجز فيلا/عقار كامل) نتحقق من الـ Property
                    bool isPropertyBooked = await _context.Reservations
                        .AnyAsync(r => r.PropertyId == reservationDto.PropertyId &&
                                       r.ParkingSpotId == null &&
                                       r.Status == "Confirmed" &&
                                       reservationDto.StartDate < r.EndTime &&
                                       reservationDto.EndDate > r.StartTime);

                    if (isPropertyBooked)
                        return BadRequest(new { success = false, message = "هذه الفيلا محجوزة بالفعل في الفترة المحددة." });
                }

                var reservation = new Reservation
                {
                    PropertyId = reservationDto.PropertyId,
                    ParkingSpotId = reservationDto.ParkingSpotId,
                    UserId = reservationDto.UserId,
                    StartTime = reservationDto.StartDate,
                    EndTime = reservationDto.EndDate,
                    TotalPrice = reservationDto.TotalPrice,
                    QrCodeData = $"RP-{reservationDto.UserId}-{DateTime.UtcNow.Ticks.ToString().Substring(10)}",
                    Status = "Confirmed",
                    CreatedAt = DateTime.UtcNow,
                    CarPlateNumber = "N/A",
                    BookingType = "Digital-Order"
                };

                if (spot != null) spot.Status = "Busy";
                _context.Reservations.Add(reservation);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { success = true, message = "تم الحجز بنجاح", reservationId = reservation.Id });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { success = false, message = "خطأ في قاعدة البيانات", error = ex.Message });
            }
        }

        [HttpDelete("CancelBySpot/{spotId}")]
        public async Task<IActionResult> CancelBySpot(int spotId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var reservation = await _context.Reservations
                    .Where(r => r.ParkingSpotId == spotId && r.Status == "Confirmed")
                    .OrderByDescending(r => r.CreatedAt)
                    .FirstOrDefaultAsync();

                if (reservation == null) return NotFound(new { message = "No active reservation found." });

                var spot = await _context.ParkingSpots.FindAsync(spotId);
                if (spot != null) spot.Status = "Available";

                reservation.Status = "Cancelled";
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { success = true, message = "تم إلغاء الحجز بنجاح" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(new { success = false, message = "خطأ أثناء الإلغاء", error = ex.Message });
            }
        }

        [HttpDelete("Cancel/{reservationId}")]
        public async Task<IActionResult> CancelReservation(int reservationId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var reservation = await _context.Reservations
                    .Include(r => r.ParkingSpot)
                    .FirstOrDefaultAsync(r => r.Id == reservationId);

                if (reservation == null) return NotFound(new { message = "Reservation not found." });
                if (reservation.ParkingSpot != null) reservation.ParkingSpot.Status = "Available";

                reservation.Status = "Cancelled";
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { success = true, message = "تم إلغاء الحجز بنجاح" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(new { success = false, message = "خطأ أثناء الإلغاء", error = ex.Message });
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateReservationStatus(int id, [FromBody] UpdateStatusDto statusDto)
        {
            var reservation = await _context.Reservations
                .Include(r => r.ParkingSpot)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null) return NotFound(new { message = "Reservation not found." });

            if ((statusDto.Status == "Cancelled" || statusDto.Status == "Completed") && reservation.ParkingSpot != null)
                reservation.ParkingSpot.Status = "Available";

            reservation.Status = statusDto.Status;
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "تم تحديث الحالة بنجاح" });
        }
    }

    public class UpdateStatusDto
    {
        public string Status { get; set; } = string.Empty;
    }
}