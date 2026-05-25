using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartParkingF.API.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم الكامل مطلوب")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "الاسم يجب أن يكون بين 2 و 100 حرف")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح")]
        public string Email { get; set; } = string.Empty;

        // كلمة المرور المشفرة - لا تُرسل للـ Frontend أبداً
        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;

        [Phone(ErrorMessage = "رقم الهاتف غير صالح")]
        public string? Phone { get; set; }

        [StringLength(20)]
        public string? CarPlateNumber { get; set; }

        public string AccountType { get; set; } = "Individual";

        public string Role { get; set; } = "User";

        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Refresh Token للـ JWT
        [JsonIgnore]
        public string? RefreshToken { get; set; }

        [JsonIgnore]
        public DateTime? RefreshTokenExpiryTime { get; set; }

        // بيانات البطاقة - نخزن آخر 4 أرقام فقط مشفرة
        [JsonIgnore]
        public string? CardLastFourDigits { get; set; }

        public bool HasLinkedCard { get; set; } = false;
    }
}