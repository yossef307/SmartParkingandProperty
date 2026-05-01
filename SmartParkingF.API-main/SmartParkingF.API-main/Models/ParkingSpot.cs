using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkingF.API.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        [Required]
        public string SpotNumber { get; set; } = string.Empty;

        public string? Zone { get; set; }

        public string? Location { get; set; }

        public string Status { get; set; } = "Available"; // Available, Busy, Maintenance

        public decimal PricePerHour { get; set; }

        public decimal PricePerNight { get; set; }

        // ✅ إضافة الـ PropertyId لربط الركنة بالفيلا (الفيلا رقم 1 في الـ Seed Data)
        public int PropertyId { get; set; }

        // إعداد العلاقة (Navigation Property)
        [ForeignKey("PropertyId")]
        public Property? Property { get; set; }
    }
}