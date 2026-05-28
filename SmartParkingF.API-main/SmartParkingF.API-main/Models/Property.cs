using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartParkingF.API.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // للربط مع الأكواد اللي بتنادي على Title
        public string Title { get => Name; set => Name = value; }

        public string Location { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // السعر العام (للإيجار)
        public decimal Price { get; set; }

        // ده اللي الـ Controller بيدور عليه عشان يحسب فاتورة الحجز
        public decimal PricePerNight { get => Price; set => Price = value; }

        public decimal PricePerHour { get; set; }

        // ✅ خصائص البيع الجديدة
        public string ListingType { get; set; } = "Rent"; // "Rent" او "Sale" او "Both"
        public decimal? SalePrice { get; set; } // سعر البيع (nullable لو للايجار فقط)
        public bool IsSold { get; set; } = false; // هل تم بيعها

        public int TotalSpots { get; set; }

        // خصائص العرض في الـ React
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public double Rating { get; set; }
        public bool HasSmartParking { get; set; }

        public string ImageUrl { get; set; } = "https://images.unsplash.com/photo-1506521781263-d8422e82f27a";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // علاقة مع الحجوزات عشان الـ Entity Framework
        public List<Reservation>? Reservations { get; set; }

        // علاقة مع المبيعات
        public List<Sale>? Sales { get; set; }
    }
}