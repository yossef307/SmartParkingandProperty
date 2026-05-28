using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;

namespace SmartParkingF.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingSpotsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParkingSpotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParkingSpots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAll()
        {
            return await _context.ParkingSpots
                .Select(s => new {
                    s.Id,
                    s.SpotNumber,
                    s.Zone,
                    s.Location,
                    s.Status,
                    s.PricePerHour,
                    s.PricePerNight,
                    s.PropertyId
                })
                .ToListAsync();
        }

        // ✅ GET: api/ParkingSpots/ByProperty/3
        [HttpGet("ByProperty/{propertyId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetByProperty(int propertyId)
        {
            var spots = await _context.ParkingSpots
                .Where(s => s.PropertyId == propertyId)
                .Select(s => new {
                    s.Id,
                    s.SpotNumber,
                    s.Zone,
                    s.Location,
                    s.Status,
                    s.PricePerHour,
                    s.PricePerNight,
                    s.PropertyId
                })
                .ToListAsync();

            return Ok(spots);
        }

        // ✅ GET: api/ParkingSpots/AvailableInZone?propertyId=3&zone=A
        [HttpGet("AvailableInZone")]
        public async Task<ActionResult<object>> GetAvailableInZone(
            [FromQuery] int propertyId,
            [FromQuery] string zone)
        {
            var spot = await _context.ParkingSpots
                .Where(s =>
                    s.PropertyId == propertyId &&
                    s.Zone != null && s.Zone.ToUpper() == zone.ToUpper() &&
                    s.Status == "Available")
                .Select(s => new {
                    s.Id,
                    s.SpotNumber,
                    s.Zone,
                    s.Status,
                    s.PricePerHour,
                    s.PricePerNight,
                    s.PropertyId
                })
                .FirstOrDefaultAsync();

            if (spot == null)
                return NotFound(new { message = $"No available spots in Zone {zone} for this property." });

            return Ok(spot);
        }

        // GET: api/ParkingSpots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            var spot = await _context.ParkingSpots
                .Where(s => s.Id == id)
                .Select(s => new {
                    s.Id,
                    s.SpotNumber,
                    s.Zone,
                    s.Location,
                    s.Status,
                    s.PricePerHour,
                    s.PricePerNight,
                    s.PropertyId
                })
                .FirstOrDefaultAsync();

            if (spot == null) return NotFound();
            return Ok(spot);
        }

        // POST: api/ParkingSpots
        [HttpPost]
        public async Task<ActionResult<ParkingSpot>> Create(ParkingSpot spot)
        {
            _context.ParkingSpots.Add(spot);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = spot.Id }, spot);
        }

        // PUT: api/ParkingSpots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ParkingSpot spot)
        {
            if (id != spot.Id) return BadRequest();
            _context.Entry(spot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/ParkingSpots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var spot = await _context.ParkingSpots.FindAsync(id);
            if (spot == null) return NotFound();
            _context.ParkingSpots.Remove(spot);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}