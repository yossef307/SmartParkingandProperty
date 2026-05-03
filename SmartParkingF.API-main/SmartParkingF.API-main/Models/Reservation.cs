using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParkingF.API.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int ParkingSpotId { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } = "Confirmed";
        public string? QrCodeData { get; set; }
        public string? CarPlateNumber { get; set; } // تأكد أن هذا موجود
        public string? BookingType { get; set; }    // تأكد أن هذا موجود
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("ParkingSpotId")]
        public virtual ParkingSpot? ParkingSpot { get; set; }
        [ForeignKey("PropertyId")]
        public virtual Property? Property { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser? User { get; set; }
    }
}