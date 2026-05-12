using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;

namespace SmartParkingF.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Settings
        [HttpGet]
        public async Task<ActionResult<SystemSettings>> GetSettings()
        {
            try
            {
                var settings = await _context.SystemSettings.FirstOrDefaultAsync();

                if (settings == null)
                {
                    // إنشاء إعدادات افتراضية إذا كانت الجداول فارغة
                    settings = new SystemSettings
                    {
                        ProjectName = "RealPark Pro",
                        SupportEmail = "admin@realstate.com",
                        LastBackupDate = DateTime.Now
                    };
                    _context.SystemSettings.Add(settings);
                    await _context.SaveChangesAsync();
                }

                return Ok(settings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Settings/update
        [HttpPost("update")]
        public async Task<IActionResult> UpdateSettings([FromBody] SystemSettings updatedSettings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existing = await _context.SystemSettings.FirstOrDefaultAsync();

                if (existing == null)
                {
                    _context.SystemSettings.Add(updatedSettings);
                }
                else
                {
                    // تحديث القيم بدقة
                    existing.ProjectName = updatedSettings.ProjectName;
                    existing.SupportEmail = updatedSettings.SupportEmail;
                    existing.IsMaintenanceMode = updatedSettings.IsMaintenanceMode;
                    existing.BookingPermissions = updatedSettings.BookingPermissions;
                    existing.ApiSecurityKey = updatedSettings.ApiSecurityKey;
                    existing.LastBackupDate = updatedSettings.LastBackupDate;
                }

                await _context.SaveChangesAsync();
                return Ok(new { message = "Settings updated successfully!", data = existing ?? updatedSettings });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating settings: {ex.Message}");
            }
        }
    }
}