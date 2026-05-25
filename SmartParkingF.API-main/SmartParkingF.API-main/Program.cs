using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;
using SmartParkingF.API.Services;
using System.Text;
using System.Text.Json;
using Serilog;

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/smartparking-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Use Serilog
builder.Host.UseSerilog();

// 1. إعداد الـ Controllers ودعم الـ camelCase
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. إعداد اتصال قاعدة البيانات
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. تسجيل الـ Services
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// 4. إعداد JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey is not configured");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

// 5. إعداد الـ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()
            ?? new[] { "http://localhost:5173", "https://localhost:5173" }
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

var app = builder.Build();

// 6. الترتيب الصحيح للـ Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// 7. Seeding مع كلمات مرور مشفرة
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var passwordService = services.GetRequiredService<IPasswordService>();

        context.Database.Migrate();

        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new AppUser
                {
                    FullName = "Super Admin",
                    Email = "admin@realstate.com",
                    Role = "Admin",
                    Status = "Active",
                    PasswordHash = passwordService.HashPassword("Admin@123"),
                    AccountType = "Individual"
                },
                new AppUser
                {
                    FullName = "Youssef Zeidan",
                    Email = "youssef@mail.com",
                    Role = "User",
                    Status = "Active",
                    PasswordHash = passwordService.HashPassword("User@123"),
                    AccountType = "Individual"
                }
            );
            context.SaveChanges();
            Log.Information("Seed users created successfully");
        }

        if (!context.Properties.Any())
        {
            var property = new Property
            {
                Name = "Luxury Modern Villa",
                Location = "Beverly Hills, Cairo",
                PricePerNight = 1250.00m,
                Description = "Luxury villa with Smart Parking integration."
            };
            context.Properties.Add(property);
            context.SaveChanges();
        }

        var firstProperty = context.Properties.FirstOrDefault();
        if (firstProperty != null && context.ParkingSpots.Count() < 90)
        {
            var oldSpots = context.ParkingSpots.ToList();
            if (oldSpots.Any())
            {
                context.ParkingSpots.RemoveRange(oldSpots);
                context.SaveChanges();
            }

            var newSpots = new List<ParkingSpot>();

            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "A" + i, Zone = "A", PricePerHour = 5, PricePerNight = 50, Status = i <= 5 ? "Occupied" : "Available", Location = "Ground Floor", PropertyId = firstProperty.Id });

            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "B" + i, Zone = "B", PricePerHour = 10, PricePerNight = 80, Status = "Available", Location = "First Floor", PropertyId = firstProperty.Id });

            for (int i = 1; i <= 30; i++)
                newSpots.Add(new ParkingSpot { SpotNumber = "C" + i, Zone = "C", PricePerHour = 15, PricePerNight = 120, Status = "Available", Location = "VIP Section", PropertyId = firstProperty.Id });

            context.ParkingSpots.AddRange(newSpots);
            context.SaveChanges();
        }

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
        Log.Error(ex, "An error occurred while seeding the database");
    }
}

app.Run();