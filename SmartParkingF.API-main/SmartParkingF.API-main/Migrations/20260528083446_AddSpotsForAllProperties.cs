using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartParkingF.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSpotsForAllProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B1", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B2", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B3", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B4", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B5", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B6", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B7", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B8", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B9", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, "B10", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C1", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C2", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C3", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C4", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C5", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C6", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C7", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C8", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C9", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, "C10", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A1", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A2", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A3", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A4", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A5", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A6", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A7", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A8", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A9", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 2, "A10", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B1" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B2" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B3" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B4" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B5" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B6" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B7" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B8" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B9" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 2, "B10" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C1", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C2", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C3", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C4", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C5", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C6", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C7", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C8", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C9", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 2, "C10", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A1", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A2", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A3", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A4", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A5", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A6", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A7", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A8", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A9", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, 3, "A10", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B1", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B2", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B3", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B4", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B5", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B6", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B7", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B8", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B9", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 3, "B10", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C1" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C2" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C3" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C4" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C5" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C6" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C7" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C8" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C9" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 3, "C10" });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Status", "Zone" },
                values: new object[,]
                {
                    { 91, "Ground Floor", 5.0m, 50.0m, 4, "A1", "Available", "A" },
                    { 92, "Ground Floor", 5.0m, 50.0m, 4, "A2", "Available", "A" },
                    { 93, "Ground Floor", 5.0m, 50.0m, 4, "A3", "Available", "A" },
                    { 94, "Ground Floor", 5.0m, 50.0m, 4, "A4", "Available", "A" },
                    { 95, "Ground Floor", 5.0m, 50.0m, 4, "A5", "Available", "A" },
                    { 96, "Ground Floor", 5.0m, 50.0m, 4, "A6", "Available", "A" },
                    { 97, "Ground Floor", 5.0m, 50.0m, 4, "A7", "Available", "A" },
                    { 98, "Ground Floor", 5.0m, 50.0m, 4, "A8", "Available", "A" },
                    { 99, "Ground Floor", 5.0m, 50.0m, 4, "A9", "Available", "A" },
                    { 100, "Ground Floor", 5.0m, 50.0m, 4, "A10", "Available", "A" },
                    { 101, "First Floor", 10.0m, 80.0m, 4, "B1", "Available", "B" },
                    { 102, "First Floor", 10.0m, 80.0m, 4, "B2", "Available", "B" },
                    { 103, "First Floor", 10.0m, 80.0m, 4, "B3", "Available", "B" },
                    { 104, "First Floor", 10.0m, 80.0m, 4, "B4", "Available", "B" },
                    { 105, "First Floor", 10.0m, 80.0m, 4, "B5", "Available", "B" },
                    { 106, "First Floor", 10.0m, 80.0m, 4, "B6", "Available", "B" },
                    { 107, "First Floor", 10.0m, 80.0m, 4, "B7", "Available", "B" },
                    { 108, "First Floor", 10.0m, 80.0m, 4, "B8", "Available", "B" },
                    { 109, "First Floor", 10.0m, 80.0m, 4, "B9", "Available", "B" },
                    { 110, "First Floor", 10.0m, 80.0m, 4, "B10", "Available", "B" },
                    { 111, "VIP Section", 15.0m, 120.0m, 4, "C1", "Available", "C" },
                    { 112, "VIP Section", 15.0m, 120.0m, 4, "C2", "Available", "C" },
                    { 113, "VIP Section", 15.0m, 120.0m, 4, "C3", "Available", "C" },
                    { 114, "VIP Section", 15.0m, 120.0m, 4, "C4", "Available", "C" },
                    { 115, "VIP Section", 15.0m, 120.0m, 4, "C5", "Available", "C" },
                    { 116, "VIP Section", 15.0m, 120.0m, 4, "C6", "Available", "C" },
                    { 117, "VIP Section", 15.0m, 120.0m, 4, "C7", "Available", "C" },
                    { 118, "VIP Section", 15.0m, 120.0m, 4, "C8", "Available", "C" },
                    { 119, "VIP Section", 15.0m, 120.0m, 4, "C9", "Available", "C" },
                    { 120, "VIP Section", 15.0m, 120.0m, 4, "C10", "Available", "C" },
                    { 121, "Ground Floor", 5.0m, 50.0m, 5, "A1", "Available", "A" },
                    { 122, "Ground Floor", 5.0m, 50.0m, 5, "A2", "Available", "A" },
                    { 123, "Ground Floor", 5.0m, 50.0m, 5, "A3", "Available", "A" },
                    { 124, "Ground Floor", 5.0m, 50.0m, 5, "A4", "Available", "A" },
                    { 125, "Ground Floor", 5.0m, 50.0m, 5, "A5", "Available", "A" },
                    { 126, "Ground Floor", 5.0m, 50.0m, 5, "A6", "Available", "A" },
                    { 127, "Ground Floor", 5.0m, 50.0m, 5, "A7", "Available", "A" },
                    { 128, "Ground Floor", 5.0m, 50.0m, 5, "A8", "Available", "A" },
                    { 129, "Ground Floor", 5.0m, 50.0m, 5, "A9", "Available", "A" },
                    { 130, "Ground Floor", 5.0m, 50.0m, 5, "A10", "Available", "A" },
                    { 131, "First Floor", 10.0m, 80.0m, 5, "B1", "Available", "B" },
                    { 132, "First Floor", 10.0m, 80.0m, 5, "B2", "Available", "B" },
                    { 133, "First Floor", 10.0m, 80.0m, 5, "B3", "Available", "B" },
                    { 134, "First Floor", 10.0m, 80.0m, 5, "B4", "Available", "B" },
                    { 135, "First Floor", 10.0m, 80.0m, 5, "B5", "Available", "B" },
                    { 136, "First Floor", 10.0m, 80.0m, 5, "B6", "Available", "B" },
                    { 137, "First Floor", 10.0m, 80.0m, 5, "B7", "Available", "B" },
                    { 138, "First Floor", 10.0m, 80.0m, 5, "B8", "Available", "B" },
                    { 139, "First Floor", 10.0m, 80.0m, 5, "B9", "Available", "B" },
                    { 140, "First Floor", 10.0m, 80.0m, 5, "B10", "Available", "B" },
                    { 141, "VIP Section", 15.0m, 120.0m, 5, "C1", "Available", "C" },
                    { 142, "VIP Section", 15.0m, 120.0m, 5, "C2", "Available", "C" },
                    { 143, "VIP Section", 15.0m, 120.0m, 5, "C3", "Available", "C" },
                    { 144, "VIP Section", 15.0m, 120.0m, 5, "C4", "Available", "C" },
                    { 145, "VIP Section", 15.0m, 120.0m, 5, "C5", "Available", "C" },
                    { 146, "VIP Section", 15.0m, 120.0m, 5, "C6", "Available", "C" },
                    { 147, "VIP Section", 15.0m, 120.0m, 5, "C7", "Available", "C" },
                    { 148, "VIP Section", 15.0m, 120.0m, 5, "C8", "Available", "C" },
                    { 149, "VIP Section", 15.0m, 120.0m, 5, "C9", "Available", "C" },
                    { 150, "VIP Section", 15.0m, 120.0m, 5, "C10", "Available", "C" },
                    { 151, "Ground Floor", 5.0m, 50.0m, 6, "A1", "Available", "A" },
                    { 152, "Ground Floor", 5.0m, 50.0m, 6, "A2", "Available", "A" },
                    { 153, "Ground Floor", 5.0m, 50.0m, 6, "A3", "Available", "A" },
                    { 154, "Ground Floor", 5.0m, 50.0m, 6, "A4", "Available", "A" },
                    { 155, "Ground Floor", 5.0m, 50.0m, 6, "A5", "Available", "A" },
                    { 156, "Ground Floor", 5.0m, 50.0m, 6, "A6", "Available", "A" },
                    { 157, "Ground Floor", 5.0m, 50.0m, 6, "A7", "Available", "A" },
                    { 158, "Ground Floor", 5.0m, 50.0m, 6, "A8", "Available", "A" },
                    { 159, "Ground Floor", 5.0m, 50.0m, 6, "A9", "Available", "A" },
                    { 160, "Ground Floor", 5.0m, 50.0m, 6, "A10", "Available", "A" },
                    { 161, "First Floor", 10.0m, 80.0m, 6, "B1", "Available", "B" },
                    { 162, "First Floor", 10.0m, 80.0m, 6, "B2", "Available", "B" },
                    { 163, "First Floor", 10.0m, 80.0m, 6, "B3", "Available", "B" },
                    { 164, "First Floor", 10.0m, 80.0m, 6, "B4", "Available", "B" },
                    { 165, "First Floor", 10.0m, 80.0m, 6, "B5", "Available", "B" },
                    { 166, "First Floor", 10.0m, 80.0m, 6, "B6", "Available", "B" },
                    { 167, "First Floor", 10.0m, 80.0m, 6, "B7", "Available", "B" },
                    { 168, "First Floor", 10.0m, 80.0m, 6, "B8", "Available", "B" },
                    { 169, "First Floor", 10.0m, 80.0m, 6, "B9", "Available", "B" },
                    { 170, "First Floor", 10.0m, 80.0m, 6, "B10", "Available", "B" },
                    { 171, "VIP Section", 15.0m, 120.0m, 6, "C1", "Available", "C" },
                    { 172, "VIP Section", 15.0m, 120.0m, 6, "C2", "Available", "C" },
                    { 173, "VIP Section", 15.0m, 120.0m, 6, "C3", "Available", "C" },
                    { 174, "VIP Section", 15.0m, 120.0m, 6, "C4", "Available", "C" },
                    { 175, "VIP Section", 15.0m, 120.0m, 6, "C5", "Available", "C" },
                    { 176, "VIP Section", 15.0m, 120.0m, 6, "C6", "Available", "C" },
                    { 177, "VIP Section", 15.0m, 120.0m, 6, "C7", "Available", "C" },
                    { 178, "VIP Section", 15.0m, 120.0m, 6, "C8", "Available", "C" },
                    { 179, "VIP Section", 15.0m, 120.0m, 6, "C9", "Available", "C" },
                    { 180, "VIP Section", 15.0m, 120.0m, 6, "C10", "Available", "C" },
                    { 181, "Ground Floor", 5.0m, 50.0m, 7, "A1", "Available", "A" },
                    { 182, "Ground Floor", 5.0m, 50.0m, 7, "A2", "Available", "A" },
                    { 183, "Ground Floor", 5.0m, 50.0m, 7, "A3", "Available", "A" },
                    { 184, "Ground Floor", 5.0m, 50.0m, 7, "A4", "Available", "A" },
                    { 185, "Ground Floor", 5.0m, 50.0m, 7, "A5", "Available", "A" },
                    { 186, "Ground Floor", 5.0m, 50.0m, 7, "A6", "Available", "A" },
                    { 187, "Ground Floor", 5.0m, 50.0m, 7, "A7", "Available", "A" },
                    { 188, "Ground Floor", 5.0m, 50.0m, 7, "A8", "Available", "A" },
                    { 189, "Ground Floor", 5.0m, 50.0m, 7, "A9", "Available", "A" },
                    { 190, "Ground Floor", 5.0m, 50.0m, 7, "A10", "Available", "A" },
                    { 191, "First Floor", 10.0m, 80.0m, 7, "B1", "Available", "B" },
                    { 192, "First Floor", 10.0m, 80.0m, 7, "B2", "Available", "B" },
                    { 193, "First Floor", 10.0m, 80.0m, 7, "B3", "Available", "B" },
                    { 194, "First Floor", 10.0m, 80.0m, 7, "B4", "Available", "B" },
                    { 195, "First Floor", 10.0m, 80.0m, 7, "B5", "Available", "B" },
                    { 196, "First Floor", 10.0m, 80.0m, 7, "B6", "Available", "B" },
                    { 197, "First Floor", 10.0m, 80.0m, 7, "B7", "Available", "B" },
                    { 198, "First Floor", 10.0m, 80.0m, 7, "B8", "Available", "B" },
                    { 199, "First Floor", 10.0m, 80.0m, 7, "B9", "Available", "B" },
                    { 200, "First Floor", 10.0m, 80.0m, 7, "B10", "Available", "B" },
                    { 201, "VIP Section", 15.0m, 120.0m, 7, "C1", "Available", "C" },
                    { 202, "VIP Section", 15.0m, 120.0m, 7, "C2", "Available", "C" },
                    { 203, "VIP Section", 15.0m, 120.0m, 7, "C3", "Available", "C" },
                    { 204, "VIP Section", 15.0m, 120.0m, 7, "C4", "Available", "C" },
                    { 205, "VIP Section", 15.0m, 120.0m, 7, "C5", "Available", "C" },
                    { 206, "VIP Section", 15.0m, 120.0m, 7, "C6", "Available", "C" },
                    { 207, "VIP Section", 15.0m, 120.0m, 7, "C7", "Available", "C" },
                    { 208, "VIP Section", 15.0m, 120.0m, 7, "C8", "Available", "C" },
                    { 209, "VIP Section", 15.0m, 120.0m, 7, "C9", "Available", "C" },
                    { 210, "VIP Section", 15.0m, 120.0m, 7, "C10", "Available", "C" },
                    { 211, "Ground Floor", 5.0m, 50.0m, 8, "A1", "Available", "A" },
                    { 212, "Ground Floor", 5.0m, 50.0m, 8, "A2", "Available", "A" },
                    { 213, "Ground Floor", 5.0m, 50.0m, 8, "A3", "Available", "A" },
                    { 214, "Ground Floor", 5.0m, 50.0m, 8, "A4", "Available", "A" },
                    { 215, "Ground Floor", 5.0m, 50.0m, 8, "A5", "Available", "A" },
                    { 216, "Ground Floor", 5.0m, 50.0m, 8, "A6", "Available", "A" },
                    { 217, "Ground Floor", 5.0m, 50.0m, 8, "A7", "Available", "A" },
                    { 218, "Ground Floor", 5.0m, 50.0m, 8, "A8", "Available", "A" },
                    { 219, "Ground Floor", 5.0m, 50.0m, 8, "A9", "Available", "A" },
                    { 220, "Ground Floor", 5.0m, 50.0m, 8, "A10", "Available", "A" },
                    { 221, "First Floor", 10.0m, 80.0m, 8, "B1", "Available", "B" },
                    { 222, "First Floor", 10.0m, 80.0m, 8, "B2", "Available", "B" },
                    { 223, "First Floor", 10.0m, 80.0m, 8, "B3", "Available", "B" },
                    { 224, "First Floor", 10.0m, 80.0m, 8, "B4", "Available", "B" },
                    { 225, "First Floor", 10.0m, 80.0m, 8, "B5", "Available", "B" },
                    { 226, "First Floor", 10.0m, 80.0m, 8, "B6", "Available", "B" },
                    { 227, "First Floor", 10.0m, 80.0m, 8, "B7", "Available", "B" },
                    { 228, "First Floor", 10.0m, 80.0m, 8, "B8", "Available", "B" },
                    { 229, "First Floor", 10.0m, 80.0m, 8, "B9", "Available", "B" },
                    { 230, "First Floor", 10.0m, 80.0m, 8, "B10", "Available", "B" },
                    { 231, "VIP Section", 15.0m, 120.0m, 8, "C1", "Available", "C" },
                    { 232, "VIP Section", 15.0m, 120.0m, 8, "C2", "Available", "C" },
                    { 233, "VIP Section", 15.0m, 120.0m, 8, "C3", "Available", "C" },
                    { 234, "VIP Section", 15.0m, 120.0m, 8, "C4", "Available", "C" },
                    { 235, "VIP Section", 15.0m, 120.0m, 8, "C5", "Available", "C" },
                    { 236, "VIP Section", 15.0m, 120.0m, 8, "C6", "Available", "C" },
                    { 237, "VIP Section", 15.0m, 120.0m, 8, "C7", "Available", "C" },
                    { 238, "VIP Section", 15.0m, 120.0m, 8, "C8", "Available", "C" },
                    { 239, "VIP Section", 15.0m, 120.0m, 8, "C9", "Available", "C" },
                    { 240, "VIP Section", 15.0m, 120.0m, 8, "C10", "Available", "C" },
                    { 241, "Ground Floor", 5.0m, 50.0m, 9, "A1", "Available", "A" },
                    { 242, "Ground Floor", 5.0m, 50.0m, 9, "A2", "Available", "A" },
                    { 243, "Ground Floor", 5.0m, 50.0m, 9, "A3", "Available", "A" },
                    { 244, "Ground Floor", 5.0m, 50.0m, 9, "A4", "Available", "A" },
                    { 245, "Ground Floor", 5.0m, 50.0m, 9, "A5", "Available", "A" },
                    { 246, "Ground Floor", 5.0m, 50.0m, 9, "A6", "Available", "A" },
                    { 247, "Ground Floor", 5.0m, 50.0m, 9, "A7", "Available", "A" },
                    { 248, "Ground Floor", 5.0m, 50.0m, 9, "A8", "Available", "A" },
                    { 249, "Ground Floor", 5.0m, 50.0m, 9, "A9", "Available", "A" },
                    { 250, "Ground Floor", 5.0m, 50.0m, 9, "A10", "Available", "A" },
                    { 251, "First Floor", 10.0m, 80.0m, 9, "B1", "Available", "B" },
                    { 252, "First Floor", 10.0m, 80.0m, 9, "B2", "Available", "B" },
                    { 253, "First Floor", 10.0m, 80.0m, 9, "B3", "Available", "B" },
                    { 254, "First Floor", 10.0m, 80.0m, 9, "B4", "Available", "B" },
                    { 255, "First Floor", 10.0m, 80.0m, 9, "B5", "Available", "B" },
                    { 256, "First Floor", 10.0m, 80.0m, 9, "B6", "Available", "B" },
                    { 257, "First Floor", 10.0m, 80.0m, 9, "B7", "Available", "B" },
                    { 258, "First Floor", 10.0m, 80.0m, 9, "B8", "Available", "B" },
                    { 259, "First Floor", 10.0m, 80.0m, 9, "B9", "Available", "B" },
                    { 260, "First Floor", 10.0m, 80.0m, 9, "B10", "Available", "B" },
                    { 261, "VIP Section", 15.0m, 120.0m, 9, "C1", "Available", "C" },
                    { 262, "VIP Section", 15.0m, 120.0m, 9, "C2", "Available", "C" },
                    { 263, "VIP Section", 15.0m, 120.0m, 9, "C3", "Available", "C" },
                    { 264, "VIP Section", 15.0m, 120.0m, 9, "C4", "Available", "C" },
                    { 265, "VIP Section", 15.0m, 120.0m, 9, "C5", "Available", "C" },
                    { 266, "VIP Section", 15.0m, 120.0m, 9, "C6", "Available", "C" },
                    { 267, "VIP Section", 15.0m, 120.0m, 9, "C7", "Available", "C" },
                    { 268, "VIP Section", 15.0m, 120.0m, 9, "C8", "Available", "C" },
                    { 269, "VIP Section", 15.0m, 120.0m, 9, "C9", "Available", "C" },
                    { 270, "VIP Section", 15.0m, 120.0m, 9, "C10", "Available", "C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A11", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A12", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A13", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A14", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A15", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A16", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A17", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A18", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A19", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A20", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A21", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A22", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A23", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A24", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A25", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A26", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A27", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A28", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A29", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "SpotNumber", "Zone" },
                values: new object[] { "Ground Floor", 5.0m, 50.0m, "A30", "A" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B1", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B2", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B3", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B4", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B5", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B6", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B7", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B8", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B9", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B10", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B11" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B12" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B13" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B14" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B15" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B16" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B17" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B18" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B19" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "B20" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B21", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B22", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B23", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B24", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B25", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B26", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B27", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B28", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B29", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "First Floor", 10.0m, 80.0m, 1, "B30", "B" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C1", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C2", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C3", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C4", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C5", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C6", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C7", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C8", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C9", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C10", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C11", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C12", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C13", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C14", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C15", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C16", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C17", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C18", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C19", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Zone" },
                values: new object[] { "VIP Section", 15.0m, 120.0m, 1, "C20", "C" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C21" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C22" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C23" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C24" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C25" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C26" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C27" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C28" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C29" });

            migrationBuilder.UpdateData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "PropertyId", "SpotNumber" },
                values: new object[] { 1, "C30" });
        }
    }
}
