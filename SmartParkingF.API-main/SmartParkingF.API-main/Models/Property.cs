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

        // ✅ التعديل الجوهري: توحيد مسميات السعر
        public decimal Price { get; set; } // السعر العام

        // ده اللي الـ Controller بيدور عليه عشان يحسب فاتورة الحجز
        public decimal PricePerNight { get => Price; set => Price = value; }

        public decimal PricePerHour { get; set; }

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
    }
}