using System.ComponentModel.DataAnnotations;

namespace SmartParkingF.API.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? CarPlateNumber { get; set; }

        public string AccountType { get; set; } = "Individual";

        public string Role { get; set; } = "User";

        public string Status { get; set; } = "Active";

        // أضفنا دي عشان تتوافق مع كود الـ Seeding اللي بعته
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}