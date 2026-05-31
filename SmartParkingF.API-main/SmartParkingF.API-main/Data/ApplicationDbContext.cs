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
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(entity => {
                entity.HasIndex(u => u.Email).IsUnique();
            });

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

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasOne(s => s.Property)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(s => s.PropertyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Buyer)
                    .WithMany()
                    .HasForeignKey(s => s.BuyerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(s => s.SalePrice).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ParkingSpot>().Property(p => p.PricePerHour).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ParkingSpot>().Property(p => p.PricePerNight).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Property>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Property>().Property(p => p.PricePerHour).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Property>().Property(p => p.PricePerNight).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Property>().Property(p => p.SalePrice).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Name = "Luxury Modern Villa",
                    Location = "Beverly Hills, Cairo",
                    Price = 1250.0m,
                    PricePerHour = 150.0m,
                    PricePerNight = 1250.0m,
                    ListingType = "Both",
                    SalePrice = 2500000.0m,
                    IsSold = false,
                    Description = "Smart Villa with private parking",
                    TotalSpots = 90,
                    Bedrooms = 4,
                    Bathrooms = 3,
                    Rating = 4.9,
                    HasSmartParking = true,
                    ImageUrl = "https://images.unsplash.com/photo-1506521781263-d8422e82f27a",
                    CreatedAt = new DateTime(2026, 4, 30)
                }
            );

            // ✅ توليد 30 spot لكل property من 1 لـ 24
            var allSpots = new List<ParkingSpot>();
            int currentId = 1;

            for (int propId = 1; propId <= 24; propId++)
            {
                // Zone A: 10 Spots
                for (int i = 1; i <= 10; i++)
                    allSpots.Add(new ParkingSpot
                    {
                        Id = currentId++,
                        SpotNumber = $"A{i}",
                        Zone = "A",
                        Status = "Available",
                        PricePerHour = 5.0m,
                        PricePerNight = 50.0m,
                        Location = "Ground Floor",
                        PropertyId = propId
                    });

                // Zone B: 10 Spots
                for (int i = 1; i <= 10; i++)
                    allSpots.Add(new ParkingSpot
                    {
                        Id = currentId++,
                        SpotNumber = $"B{i}",
                        Zone = "B",
                        Status = "Available",
                        PricePerHour = 10.0m,
                        PricePerNight = 80.0m,
                        Location = "First Floor",
                        PropertyId = propId
                    });

                // Zone C: 10 Spots
                for (int i = 1; i <= 10; i++)
                    allSpots.Add(new ParkingSpot
                    {
                        Id = currentId++,
                        SpotNumber = $"C{i}",
                        Zone = "C",
                        Status = "Available",
                        PricePerHour = 15.0m,
                        PricePerNight = 120.0m,
                        Location = "VIP Section",
                        PropertyId = propId
                    });
            }

            modelBuilder.Entity<ParkingSpot>().HasData(allSpots);
        }
    }
}