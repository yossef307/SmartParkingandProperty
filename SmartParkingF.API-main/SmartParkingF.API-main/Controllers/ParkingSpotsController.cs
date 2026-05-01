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
        public async Task<ActionResult<IEnumerable<ParkingSpot>>> GetAll()
        {
            return await _context.ParkingSpots.ToListAsync();
        }

        // GET: api/ParkingSpots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingSpot>> GetById(int id)
        {
            var spot = await _context.ParkingSpots.FindAsync(id);
            if (spot == null) return NotFound();

            return spot;
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