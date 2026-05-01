using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
                return BadRequest(new { message = "الرجاء إدخال البريد الإلكتروني وكلمة المرور." });

            // تنظيف البيانات من أي مسافات زائدة
            var cleanEmail = login.Email.Trim().ToLower();
            var cleanPassword = login.Password.Trim();

            // طباعة للتأكد في الـ Output window بتاع Visual Studio
            Console.WriteLine($"Login Attempt -> Email: [{cleanEmail}], Password: [{cleanPassword}]");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == cleanEmail);

            if (user == null || user.Password != cleanPassword)
            {
                return Unauthorized(new { message = "البريد الإلكتروني أو كلمة المرور غير صحيحة." });
            }

            return Ok(new
            {
                fullName = user.FullName,
                email = user.Email,
                // تأكيد تحديد الـ role كـ admin لو الإيميل هو إيميل الإدمن
                role = (user.Email.ToLower() == "admin@realstate.com" || user.Role?.ToLower() == "admin") ? "admin" : "user",
                phone = user.Phone,
                carPlateNumber = user.CarPlateNumber
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register([FromBody] AppUser user)
        {
            try
            {
                if (user == null) return BadRequest(new { message = "البيانات فارغة." });

                var cleanEmail = user.Email.Trim().ToLower();
                bool emailExists = await _context.Users.AnyAsync(u => u.Email.ToLower() == cleanEmail);

                if (emailExists) return BadRequest(new { message = "هذا البريد الإلكتروني مسجل بالفعل." });

                user.Email = cleanEmail;
                if (string.IsNullOrEmpty(user.Status)) user.Status = "Active";
                if (string.IsNullOrEmpty(user.Role)) user.Role = "User";

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "حدث خطأ أثناء محاولة التسجيل." });
            }
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] AppUser updatedUser)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == updatedUser.Email.ToLower());
                if (user == null) return NotFound(new { message = "المستخدم غير موجود." });

                user.FullName = updatedUser.FullName;
                user.Phone = updatedUser.Phone;
                user.CarPlateNumber = updatedUser.CarPlateNumber;

                await _context.SaveChangesAsync();
                return Ok(new { message = "تم تحديث البيانات بنجاح ✅", user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "خطأ في تحديث البيانات." });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() => await _context.Users.ToListAsync();

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound(new { message = "المستخدم غير موجود." });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "تم الحذف بنجاح." });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}