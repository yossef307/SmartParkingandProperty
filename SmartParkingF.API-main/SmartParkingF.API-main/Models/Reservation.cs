using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkingF.API.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        // ربط الحجز بمكان الركن
        [Required]
        public int ParkingSpotId { get; set; }
        public virtual ParkingSpot? ParkingSpot { get; set; }

        // ربط الحجز بالعقار (الفيلا)
        [Required]
        public int PropertyId { get; set; }
        public virtual Property? Property { get; set; }

        // ✅ تعديل: استخدام UserId بدلاً من Email لربط احترافي بقاعدة البيانات
        [Required]
        public int UserId { get; set; }
        public virtual AppUser? User { get; set; }

        public string? CarPlateNumber { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        // ✅ التكلفة الإجمالية
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public string? QrCodeData { get; set; }

        [Required]
        public string Status { get; set; } = "Confirmed"; // Confirmed, Cancelled, Completed

        public string? BookingType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserEmail { get; internal set; }
    }
}