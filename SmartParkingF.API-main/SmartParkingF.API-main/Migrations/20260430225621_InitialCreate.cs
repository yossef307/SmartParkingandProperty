using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartParkingF.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSpots = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    HasSmartParking = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarPlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarPlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QrCodeData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_ParkingSpots_ParkingSpotId",
                        column: x => x.ParkingSpotId,
                        principalTable: "ParkingSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Bathrooms", "Bedrooms", "CreatedAt", "Description", "HasSmartParking", "ImageUrl", "Location", "Name", "Price", "PricePerHour", "PricePerNight", "Rating", "Title", "TotalSpots" },
                values: new object[] { 1, 3, 4, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smart Villa with private parking", true, "https://images.unsplash.com/photo-1506521781263-d8422e82f27a", "Beverly Hills, Cairo", "Luxury Modern Villa", 1250.0m, 150.0m, 1250.0m, 4.9000000000000004, "Luxury Modern Villa", 90 });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Status", "Zone" },
                values: new object[,]
                {
                    { 1, "Ground Floor", 5.0m, 50.0m, 1, "A1", "Available", "A" },
                    { 2, "Ground Floor", 5.0m, 50.0m, 1, "A2", "Available", "A" },
                    { 3, "Ground Floor", 5.0m, 50.0m, 1, "A3", "Available", "A" },
                    { 4, "Ground Floor", 5.0m, 50.0m, 1, "A4", "Available", "A" },
                    { 5, "Ground Floor", 5.0m, 50.0m, 1, "A5", "Available", "A" },
                    { 6, "Ground Floor", 5.0m, 50.0m, 1, "A6", "Available", "A" },
                    { 7, "Ground Floor", 5.0m, 50.0m, 1, "A7", "Available", "A" },
                    { 8, "Ground Floor", 5.0m, 50.0m, 1, "A8", "Available", "A" },
                    { 9, "Ground Floor", 5.0m, 50.0m, 1, "A9", "Available", "A" },
                    { 10, "Ground Floor", 5.0m, 50.0m, 1, "A10", "Available", "A" },
                    { 11, "Ground Floor", 5.0m, 50.0m, 1, "A11", "Available", "A" },
                    { 12, "Ground Floor", 5.0m, 50.0m, 1, "A12", "Available", "A" },
                    { 13, "Ground Floor", 5.0m, 50.0m, 1, "A13", "Available", "A" },
                    { 14, "Ground Floor", 5.0m, 50.0m, 1, "A14", "Available", "A" },
                    { 15, "Ground Floor", 5.0m, 50.0m, 1, "A15", "Available", "A" },
                    { 16, "Ground Floor", 5.0m, 50.0m, 1, "A16", "Available", "A" },
                    { 17, "Ground Floor", 5.0m, 50.0m, 1, "A17", "Available", "A" },
                    { 18, "Ground Floor", 5.0m, 50.0m, 1, "A18", "Available", "A" },
                    { 19, "Ground Floor", 5.0m, 50.0m, 1, "A19", "Available", "A" },
                    { 20, "Ground Floor", 5.0m, 50.0m, 1, "A20", "Available", "A" },
                    { 21, "Ground Floor", 5.0m, 50.0m, 1, "A21", "Available", "A" },
                    { 22, "Ground Floor", 5.0m, 50.0m, 1, "A22", "Available", "A" },
                    { 23, "Ground Floor", 5.0m, 50.0m, 1, "A23", "Available", "A" },
                    { 24, "Ground Floor", 5.0m, 50.0m, 1, "A24", "Available", "A" },
                    { 25, "Ground Floor", 5.0m, 50.0m, 1, "A25", "Available", "A" },
                    { 26, "Ground Floor", 5.0m, 50.0m, 1, "A26", "Available", "A" },
                    { 27, "Ground Floor", 5.0m, 50.0m, 1, "A27", "Available", "A" },
                    { 28, "Ground Floor", 5.0m, 50.0m, 1, "A28", "Available", "A" },
                    { 29, "Ground Floor", 5.0m, 50.0m, 1, "A29", "Available", "A" },
                    { 30, "Ground Floor", 5.0m, 50.0m, 1, "A30", "Available", "A" },
                    { 31, "First Floor", 10.0m, 80.0m, 1, "B1", "Available", "B" },
                    { 32, "First Floor", 10.0m, 80.0m, 1, "B2", "Available", "B" },
                    { 33, "First Floor", 10.0m, 80.0m, 1, "B3", "Available", "B" },
                    { 34, "First Floor", 10.0m, 80.0m, 1, "B4", "Available", "B" },
                    { 35, "First Floor", 10.0m, 80.0m, 1, "B5", "Available", "B" },
                    { 36, "First Floor", 10.0m, 80.0m, 1, "B6", "Available", "B" },
                    { 37, "First Floor", 10.0m, 80.0m, 1, "B7", "Available", "B" },
                    { 38, "First Floor", 10.0m, 80.0m, 1, "B8", "Available", "B" },
                    { 39, "First Floor", 10.0m, 80.0m, 1, "B9", "Available", "B" },
                    { 40, "First Floor", 10.0m, 80.0m, 1, "B10", "Available", "B" },
                    { 41, "First Floor", 10.0m, 80.0m, 1, "B11", "Available", "B" },
                    { 42, "First Floor", 10.0m, 80.0m, 1, "B12", "Available", "B" },
                    { 43, "First Floor", 10.0m, 80.0m, 1, "B13", "Available", "B" },
                    { 44, "First Floor", 10.0m, 80.0m, 1, "B14", "Available", "B" },
                    { 45, "First Floor", 10.0m, 80.0m, 1, "B15", "Available", "B" },
                    { 46, "First Floor", 10.0m, 80.0m, 1, "B16", "Available", "B" },
                    { 47, "First Floor", 10.0m, 80.0m, 1, "B17", "Available", "B" },
                    { 48, "First Floor", 10.0m, 80.0m, 1, "B18", "Available", "B" },
                    { 49, "First Floor", 10.0m, 80.0m, 1, "B19", "Available", "B" },
                    { 50, "First Floor", 10.0m, 80.0m, 1, "B20", "Available", "B" },
                    { 51, "First Floor", 10.0m, 80.0m, 1, "B21", "Available", "B" },
                    { 52, "First Floor", 10.0m, 80.0m, 1, "B22", "Available", "B" },
                    { 53, "First Floor", 10.0m, 80.0m, 1, "B23", "Available", "B" },
                    { 54, "First Floor", 10.0m, 80.0m, 1, "B24", "Available", "B" },
                    { 55, "First Floor", 10.0m, 80.0m, 1, "B25", "Available", "B" },
                    { 56, "First Floor", 10.0m, 80.0m, 1, "B26", "Available", "B" },
                    { 57, "First Floor", 10.0m, 80.0m, 1, "B27", "Available", "B" },
                    { 58, "First Floor", 10.0m, 80.0m, 1, "B28", "Available", "B" },
                    { 59, "First Floor", 10.0m, 80.0m, 1, "B29", "Available", "B" },
                    { 60, "First Floor", 10.0m, 80.0m, 1, "B30", "Available", "B" },
                    { 61, "VIP Section", 15.0m, 120.0m, 1, "C1", "Available", "C" },
                    { 62, "VIP Section", 15.0m, 120.0m, 1, "C2", "Available", "C" },
                    { 63, "VIP Section", 15.0m, 120.0m, 1, "C3", "Available", "C" },
                    { 64, "VIP Section", 15.0m, 120.0m, 1, "C4", "Available", "C" },
                    { 65, "VIP Section", 15.0m, 120.0m, 1, "C5", "Available", "C" },
                    { 66, "VIP Section", 15.0m, 120.0m, 1, "C6", "Available", "C" },
                    { 67, "VIP Section", 15.0m, 120.0m, 1, "C7", "Available", "C" },
                    { 68, "VIP Section", 15.0m, 120.0m, 1, "C8", "Available", "C" },
                    { 69, "VIP Section", 15.0m, 120.0m, 1, "C9", "Available", "C" },
                    { 70, "VIP Section", 15.0m, 120.0m, 1, "C10", "Available", "C" },
                    { 71, "VIP Section", 15.0m, 120.0m, 1, "C11", "Available", "C" },
                    { 72, "VIP Section", 15.0m, 120.0m, 1, "C12", "Available", "C" },
                    { 73, "VIP Section", 15.0m, 120.0m, 1, "C13", "Available", "C" },
                    { 74, "VIP Section", 15.0m, 120.0m, 1, "C14", "Available", "C" },
                    { 75, "VIP Section", 15.0m, 120.0m, 1, "C15", "Available", "C" },
                    { 76, "VIP Section", 15.0m, 120.0m, 1, "C16", "Available", "C" },
                    { 77, "VIP Section", 15.0m, 120.0m, 1, "C17", "Available", "C" },
                    { 78, "VIP Section", 15.0m, 120.0m, 1, "C18", "Available", "C" },
                    { 79, "VIP Section", 15.0m, 120.0m, 1, "C19", "Available", "C" },
                    { 80, "VIP Section", 15.0m, 120.0m, 1, "C20", "Available", "C" },
                    { 81, "VIP Section", 15.0m, 120.0m, 1, "C21", "Available", "C" },
                    { 82, "VIP Section", 15.0m, 120.0m, 1, "C22", "Available", "C" },
                    { 83, "VIP Section", 15.0m, 120.0m, 1, "C23", "Available", "C" },
                    { 84, "VIP Section", 15.0m, 120.0m, 1, "C24", "Available", "C" },
                    { 85, "VIP Section", 15.0m, 120.0m, 1, "C25", "Available", "C" },
                    { 86, "VIP Section", 15.0m, 120.0m, 1, "C26", "Available", "C" },
                    { 87, "VIP Section", 15.0m, 120.0m, 1, "C27", "Available", "C" },
                    { 88, "VIP Section", 15.0m, 120.0m, 1, "C28", "Available", "C" },
                    { 89, "VIP Section", 15.0m, 120.0m, 1, "C29", "Available", "C" },
                    { 90, "VIP Section", 15.0m, 120.0m, 1, "C30", "Available", "C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_PropertyId",
                table: "ParkingSpots",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ParkingSpotId",
                table: "Reservations",
                column: "ParkingSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PropertyId",
                table: "Reservations",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
