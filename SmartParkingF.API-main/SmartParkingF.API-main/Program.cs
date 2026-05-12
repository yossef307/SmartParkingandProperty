using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// 1. إعداد الـ Controllers ودعم الـ camelCase ليتوافق مع React
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // يضمن تحويل PropertyName في C# إلى propertyName في JSON
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        // يتجنب مشاكل الـ Object Cycles إذا كان هناك علاقات دائرية
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. إعداد اتصال قاعدة البيانات
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. إعداد الـ CORS - تم تعديله ليكون أكثر مرونة أثناء التطوير
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => {
        policy.WithOrigins("http://localhost:5173") // تحديد بورت React لزيادة الأمان
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // للسماح بإرسال الـ Cookies أو الـ Headers الخاصة إذا احتجت مستقبلاً
    });
});

var app = builder.Build();

// 4. ترتيب الـ Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// الترتيب هنا حيوي جداً لعمل الـ API مع الـ Frontend
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

// 5. الـ Seeding والـ Migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // تطبيق المايجريشن تلقائياً عند تشغيل المشروع
        context.Database.Migrate();

        // إدخال مستخدمين تجريبيين
        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new AppUser { FullName = "Super Admin", Email = "admin@realstate.com", Role = "Admin", Status = "Active", Password = "123", AccountType = "Individual" },
                new AppUser { FullName = "Youssef Zeidan", Email = "youssef@mail.com", Role = "User", Status = "Active", Password = "123", AccountType = "Individual" }
            );
            context.SaveChanges();
        }

        // إدخال عقار تجريبي
        if (!context.Properties.Any())
        {
            var property = new Property
            {
                // نصيحة: يفضل ترك الـ Id لقاعدة البيانات وعدم إدخاله يدوياً إلا لو كان Identity Insert مفعل
                Name = "Luxury Modern Villa",
                Location = "Beverly Hills, Cairo",
                PricePerNight = 1250.00m,
                Description = "Luxury villa with Smart Parking integration."
            };
            context.Properties.Add(property);
            context.SaveChanges();
        }

        // الحصول على معرف العقار الأول لاستخدامه في ربط الأماكن
        var firstProperty = context.Properties.FirstOrDefault();

        // تحديث الـ 90 مكان
        if (firstProperty != null && context.ParkingSpots.Count() < 90)
        {
            // مسح القديم لضمان نظافة البيانات عند التحديث
            var oldSpots = context.ParkingSpots.ToList();
            context.ParkingSpots.RemoveRange(oldSpots);
            context.SaveChanges();

            var newSpots = new List<ParkingSpot>();
            // Zone A
            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "A" + i, Zone = "A", PricePerHour = 5, PricePerNight = 50, Status = i <= 5 ? "Occupied" : "Available", Location = "Ground Floor", PropertyId = firstProperty.Id });
            // Zone B
            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "B" + i, Zone = "B", PricePerHour = 10, PricePerNight = 80, Status = "Available", Location = "First Floor", PropertyId = firstProperty.Id });
            // Zone C
            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "C" + i, Zone = "C", PricePerHour = 15, PricePerNight = 120, Status = "Available", Location = "VIP Section", PropertyId = firstProperty.Id });

            context.ParkingSpots.AddRange(newSpots);
            context.SaveChanges();
        }

        // إضافة حجز تجريبي للتقارير
        if (!context.Reservations.Any())
        {
            var firstSpot = context.ParkingSpots.FirstOrDefault();
            if (firstProperty != null && firstSpot != null)
            {
                context.Reservations.Add(new Reservation
                {
                    PropertyId = firstProperty.Id,
                    ParkingSpotId = firstSpot.Id,
                    TotalPrice = 150.00m
                });
                context.SaveChanges();
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Seeding Error: {ex.Message}");
    }
}

app.Run();