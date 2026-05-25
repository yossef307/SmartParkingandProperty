using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;
using SmartParkingF.API.Models.DTOs;
using SmartParkingF.API.Services;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            ApplicationDbContext context,
            IPasswordService passwordService,
            ITokenService tokenService,
            ILogger<UsersController> logger)
        {
            _context = context;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var cleanEmail = request.Email.Trim().ToLower();

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == cleanEmail && u.Status == "Active");

                if (user == null)
                {
                    _logger.LogWarning("Login attempt failed for email: {Email}", cleanEmail);
                    return Unauthorized(new { message = "البريد الإلكتروني أو كلمة المرور غير صحيحة." });
                }

                if (!_passwordService.VerifyPassword(request.Password, user.PasswordHash))
                {
                    _logger.LogWarning("Invalid password attempt for user: {UserId}", user.Id);
                    return Unauthorized(new { message = "البريد الإلكتروني أو كلمة المرور غير صحيحة." });
                }

                // Generate tokens
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                // Save refresh token
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _context.SaveChangesAsync();

                _logger.LogInformation("User {UserId} logged in successfully", user.Id);

                return Ok(new AuthResponse
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role.ToLower(),
                    Phone = user.Phone,
                    CarPlateNumber = user.CarPlateNumber,
                    HasLinkedCard = user.HasLinkedCard,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    TokenExpiry = DateTime.UtcNow.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(500, new { message = "حدث خطأ أثناء تسجيل الدخول." });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var cleanEmail = request.Email.Trim().ToLower();

                if (await _context.Users.AnyAsync(u => u.Email.ToLower() == cleanEmail))
                {
                    return BadRequest(new { message = "هذا البريد الإلكتروني مسجل بالفعل." });
                }

                var user = new AppUser
                {
                    FullName = request.FullName.Trim(),
                    Email = cleanEmail,
                    PasswordHash = _passwordService.HashPassword(request.Password),
                    Phone = request.Phone?.Trim(),
                    CarPlateNumber = request.CarPlateNumber?.Trim(),
                    AccountType = request.AccountType,
                    Role = "User",
                    Status = "Active",
                    CreatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Generate tokens
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _context.SaveChangesAsync();

                _logger.LogInformation("New user registered: {UserId}", user.Id);

                return Ok(new AuthResponse
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role.ToLower(),
                    Phone = user.Phone,
                    CarPlateNumber = user.CarPlateNumber,
                    HasLinkedCard = user.HasLinkedCard,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    TokenExpiry = DateTime.UtcNow.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration");
                return StatusCode(500, new { message = "حدث خطأ أثناء التسجيل." });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

                if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                {
                    return Unauthorized(new { message = "الجلسة انتهت، الرجاء تسجيل الدخول مرة أخرى." });
                }

                var newAccessToken = _tokenService.GenerateAccessToken(user);
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    accessToken = newAccessToken,
                    refreshToken = newRefreshToken,
                    tokenExpiry = DateTime.UtcNow.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during token refresh");
                return StatusCode(500, new { message = "حدث خطأ أثناء تجديد الجلسة." });
            }
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var user = await _context.Users.FindAsync(int.Parse(userId));
                if (user != null)
                {
                    user.RefreshToken = null;
                    user.RefreshTokenExpiryTime = null;
                    await _context.SaveChangesAsync();
                }

                return Ok(new { message = "تم تسجيل الخروج بنجاح." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during logout");
                return StatusCode(500, new { message = "حدث خطأ أثناء تسجيل الخروج." });
            }
        }

        [Authorize]
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized();

                var user = await _context.Users.FindAsync(int.Parse(userId));
                if (user == null)
                    return NotFound(new { message = "المستخدم غير موجود." });

                if (!string.IsNullOrEmpty(request.FullName))
                    user.FullName = request.FullName.Trim();

                if (!string.IsNullOrEmpty(request.Phone))
                    user.Phone = request.Phone.Trim();

                if (!string.IsNullOrEmpty(request.CarPlateNumber))
                    user.CarPlateNumber = request.CarPlateNumber.Trim();

                await _context.SaveChangesAsync();

                _logger.LogInformation("User {UserId} updated profile", user.Id);

                return Ok(new
                {
                    message = "تم تحديث البيانات بنجاح",
                    user = new
                    {
                        user.Id,
                        user.FullName,
                        user.Email,
                        user.Phone,
                        user.CarPlateNumber,
                        user.HasLinkedCard,
                        user.Role
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating profile");
                return StatusCode(500, new { message = "حدث خطأ أثناء تحديث البيانات." });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetUsers()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.FullName,
                    u.Email,
                    u.Phone,
                    u.Role,
                    u.Status,
                    u.AccountType,
                    u.CreatedAt,
                    u.HasLinkedCard
                })
                .ToListAsync();

            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                    return NotFound(new { message = "المستخدم غير موجود." });

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                _logger.LogInformation("User {UserId} deleted by admin", id);

                return Ok(new { message = "تم حذف المستخدم بنجاح." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", id);
                return StatusCode(500, new { message = "حدث خطأ أثناء حذف المستخدم." });
            }
        }
    }
}