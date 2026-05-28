using System;
using System.ComponentModel.DataAnnotations;

namespace SmartParkingF.API.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public int PropertyId { get; set; }
        public Property? Property { get; set; }

        [Required]
        public int BuyerId { get; set; }
        public AppUser? Buyer { get; set; }  // <-- هنا التغيير

        public decimal SalePrice { get; set; }

        public string PaymentMethod { get; set; } = "Card";

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedAt { get; set; }
    }
}