using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. جلب كل العقارات (تعديل لضمان عدم رجوع قائمة فارغة أثناء الفحص)
        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            try
            {
                var properties = await _context.Properties.ToListAsync();

                // إذا كانت قاعدة البيانات فارغة تماماً، سنعيد بيانات وهمية للتجربة فقط
                // بمجرد أن تظهر هذه البيانات في الـ React، ستعرف أن الربط سليم 100%
                if (properties == null || properties.Count == 0)
                {
                    var fallback = new List<object>
                    {
                        new {
                            id = 1,
                            name = "Connection Test Villa",
                            location = "Database is Empty",
                            pricePerHour = 0,
                            imageUrl = "https://via.placeholder.com/400"
                        }
                    };
                    return Ok(fallback);
                }

                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // 2. جلب عقار واحد بالـ ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
                return NotFound(new { message = "Property not found" });

            return Ok(property);
        }

        // 3. إضافة عقار جديد
        [HttpPost]
        public async Task<ActionResult<Property>> PostProperty(Property property)
        {
            if (property == null) return BadRequest();

            property.CreatedAt = DateTime.Now; // تعيين الوقت تلقائياً
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
        }

        // باقي العمليات (PUT & DELETE) تبقى كما هي
    }
}