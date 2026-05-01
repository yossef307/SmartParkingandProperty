using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// 1. إعداد الـ Controllers ودعم الـ camelCase
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. إعداد اتصال قاعدة البيانات
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. إعداد الـ CORS
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 4. الـ Seeding والـ Migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // تطبيق المايجريشن تلقائياً
        context.Database.Migrate();

        // إدخال مستخدمين تجريبيين (بدون خاصية CreatedAt لتجنب الخطأ)
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new AppUser
                {
                    FullName = "Super Admin",
                    Email = "admin@realstate.com",
                    Role = "Admin",
                    Status = "Active",
                    Password = "123",
                    AccountType = "Individual"
                },
                new AppUser
                {
                    FullName = "Youssef Zeidan",
                    Email = "youssef@mail.com",
                    Role = "User",
                    Status = "Active",
                    Password = "123",
                    AccountType = "Individual"
                }
            );
            context.SaveChanges();
        }

        // تحديث الـ 90 مكان
        if (context.ParkingSpots.Count() < 90)
        {
            var oldSpots = context.ParkingSpots.ToList();
            context.ParkingSpots.RemoveRange(oldSpots);
            context.SaveChanges();

            var newSpots = new List<ParkingSpot>();
            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "A" + i, Zone = "A", PricePerHour = 5, PricePerNight = 50, Status = "Available", Location = "Ground Floor" });
            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "B" + i, Zone = "B", PricePerHour = 10, PricePerNight = 80, Status = "Available", Location = "First Floor" });
            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "C" + i, Zone = "C", PricePerHour = 15, PricePerNight = 120, Status = "Available", Location = "VIP Section" });

            context.ParkingSpots.AddRange(newSpots);
            context.SaveChanges();
        }

        if (!context.Properties.Any())
        {
            context.Properties.Add(new Property
            {
                Name = "Luxury Modern Villa",
                Location = "Beverly Hills, Cairo",
                PricePerNight = 1250.00m,
                Description = "Luxury villa with Smart Parking integration."
            });
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Seeding Error: {ex.Message}");
    }
}

app.Run();