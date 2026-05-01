using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Models;
using System;
using System.Collections.Generic;

namespace SmartParkingF.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. إعدادات المستخدم
            modelBuilder.Entity<AppUser>(entity => {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            // 2. إعدادات الحجز (Reservation)
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasOne(r => r.Property)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(r => r.PropertyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.ParkingSpot)
                    .WithMany()
                    .HasForeignKey(r => r.ParkingSpotId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(r => r.TotalPrice).HasColumnType("decimal(18,2)");
            });

            // 3. ضبط نوع البيانات الـ decimal
            modelBuilder.Entity<ParkingSpot>().Property(p => p.PricePerHour).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ParkingSpot>().Property(p => p.PricePerNight).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Property>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Property>().Property(p => p.PricePerHour).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Property>().Property(p => p.PricePerNight).HasColumnType("decimal(18,2)");

            // 4. إعداد الفيلا (Seed Property)
            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Name = "Luxury Modern Villa",
                    Location = "Beverly Hills, Cairo",
                    Price = 1250.0m,
                    PricePerHour = 150.0m,
                    PricePerNight = 1250.0m,
                    Description = "Smart Villa with private parking",
                    TotalSpots = 90, // تم التعديل ليتوافق مع الـ UI
                    Bedrooms = 4,
                    Bathrooms = 3,
                    Rating = 4.9,
                    HasSmartParking = true,
                    ImageUrl = "https://images.unsplash.com/photo-1506521781263-d8422e82f27a",
                    CreatedAt = new DateTime(2026, 4, 30)
                }
            );

            // 5. ✅ توليد الـ 90 ركنة أوتوماتيكياً (Seed Parking Spots)
            var allSpots = new List<ParkingSpot>();
            int currentId = 1;

            // Zone A: 30 Spots (1 - 30)
            for (int i = 1; i <= 30; i++)
            {
                allSpots.Add(new ParkingSpot { Id = currentId++, SpotNumber = $"A{i}", Zone = "A", Status = "Available", PricePerHour = 5.0m, PricePerNight = 50.0m, Location = "Ground Floor", PropertyId = 1 });
            }

            // Zone B: 30 Spots (31 - 60)
            for (int i = 1; i <= 30; i++)
            {
                allSpots.Add(new ParkingSpot { Id = currentId++, SpotNumber = $"B{i}", Zone = "B", Status = "Available", PricePerHour = 10.0m, PricePerNight = 80.0m, Location = "First Floor", PropertyId = 1 });
            }

            // Zone C: 30 Spots (61 - 90)
            for (int i = 1; i <= 30; i++)
            {
                allSpots.Add(new ParkingSpot { Id = currentId++, SpotNumber = $"C{i}", Zone = "C", Status = "Available", PricePerHour = 15.0m, PricePerNight = 120.0m, Location = "VIP Section", PropertyId = 1 });
            }

            modelBuilder.Entity<ParkingSpot>().HasData(allSpots);
        }
    }
}