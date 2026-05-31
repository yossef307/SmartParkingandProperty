using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartParkingF.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSpotsForProperties10To24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "Location", "PricePerHour", "PricePerNight", "PropertyId", "SpotNumber", "Status", "Zone" },
                values: new object[,]
                {
                    { 271, "Ground Floor", 5.0m, 50.0m, 10, "A1", "Available", "A" },
                    { 272, "Ground Floor", 5.0m, 50.0m, 10, "A2", "Available", "A" },
                    { 273, "Ground Floor", 5.0m, 50.0m, 10, "A3", "Available", "A" },
                    { 274, "Ground Floor", 5.0m, 50.0m, 10, "A4", "Available", "A" },
                    { 275, "Ground Floor", 5.0m, 50.0m, 10, "A5", "Available", "A" },
                    { 276, "Ground Floor", 5.0m, 50.0m, 10, "A6", "Available", "A" },
                    { 277, "Ground Floor", 5.0m, 50.0m, 10, "A7", "Available", "A" },
                    { 278, "Ground Floor", 5.0m, 50.0m, 10, "A8", "Available", "A" },
                    { 279, "Ground Floor", 5.0m, 50.0m, 10, "A9", "Available", "A" },
                    { 280, "Ground Floor", 5.0m, 50.0m, 10, "A10", "Available", "A" },
                    { 281, "First Floor", 10.0m, 80.0m, 10, "B1", "Available", "B" },
                    { 282, "First Floor", 10.0m, 80.0m, 10, "B2", "Available", "B" },
                    { 283, "First Floor", 10.0m, 80.0m, 10, "B3", "Available", "B" },
                    { 284, "First Floor", 10.0m, 80.0m, 10, "B4", "Available", "B" },
                    { 285, "First Floor", 10.0m, 80.0m, 10, "B5", "Available", "B" },
                    { 286, "First Floor", 10.0m, 80.0m, 10, "B6", "Available", "B" },
                    { 287, "First Floor", 10.0m, 80.0m, 10, "B7", "Available", "B" },
                    { 288, "First Floor", 10.0m, 80.0m, 10, "B8", "Available", "B" },
                    { 289, "First Floor", 10.0m, 80.0m, 10, "B9", "Available", "B" },
                    { 290, "First Floor", 10.0m, 80.0m, 10, "B10", "Available", "B" },
                    { 291, "VIP Section", 15.0m, 120.0m, 10, "C1", "Available", "C" },
                    { 292, "VIP Section", 15.0m, 120.0m, 10, "C2", "Available", "C" },
                    { 293, "VIP Section", 15.0m, 120.0m, 10, "C3", "Available", "C" },
                    { 294, "VIP Section", 15.0m, 120.0m, 10, "C4", "Available", "C" },
                    { 295, "VIP Section", 15.0m, 120.0m, 10, "C5", "Available", "C" },
                    { 296, "VIP Section", 15.0m, 120.0m, 10, "C6", "Available", "C" },
                    { 297, "VIP Section", 15.0m, 120.0m, 10, "C7", "Available", "C" },
                    { 298, "VIP Section", 15.0m, 120.0m, 10, "C8", "Available", "C" },
                    { 299, "VIP Section", 15.0m, 120.0m, 10, "C9", "Available", "C" },
                    { 300, "VIP Section", 15.0m, 120.0m, 10, "C10", "Available", "C" },
                    { 301, "Ground Floor", 5.0m, 50.0m, 11, "A1", "Available", "A" },
                    { 302, "Ground Floor", 5.0m, 50.0m, 11, "A2", "Available", "A" },
                    { 303, "Ground Floor", 5.0m, 50.0m, 11, "A3", "Available", "A" },
                    { 304, "Ground Floor", 5.0m, 50.0m, 11, "A4", "Available", "A" },
                    { 305, "Ground Floor", 5.0m, 50.0m, 11, "A5", "Available", "A" },
                    { 306, "Ground Floor", 5.0m, 50.0m, 11, "A6", "Available", "A" },
                    { 307, "Ground Floor", 5.0m, 50.0m, 11, "A7", "Available", "A" },
                    { 308, "Ground Floor", 5.0m, 50.0m, 11, "A8", "Available", "A" },
                    { 309, "Ground Floor", 5.0m, 50.0m, 11, "A9", "Available", "A" },
                    { 310, "Ground Floor", 5.0m, 50.0m, 11, "A10", "Available", "A" },
                    { 311, "First Floor", 10.0m, 80.0m, 11, "B1", "Available", "B" },
                    { 312, "First Floor", 10.0m, 80.0m, 11, "B2", "Available", "B" },
                    { 313, "First Floor", 10.0m, 80.0m, 11, "B3", "Available", "B" },
                    { 314, "First Floor", 10.0m, 80.0m, 11, "B4", "Available", "B" },
                    { 315, "First Floor", 10.0m, 80.0m, 11, "B5", "Available", "B" },
                    { 316, "First Floor", 10.0m, 80.0m, 11, "B6", "Available", "B" },
                    { 317, "First Floor", 10.0m, 80.0m, 11, "B7", "Available", "B" },
                    { 318, "First Floor", 10.0m, 80.0m, 11, "B8", "Available", "B" },
                    { 319, "First Floor", 10.0m, 80.0m, 11, "B9", "Available", "B" },
                    { 320, "First Floor", 10.0m, 80.0m, 11, "B10", "Available", "B" },
                    { 321, "VIP Section", 15.0m, 120.0m, 11, "C1", "Available", "C" },
                    { 322, "VIP Section", 15.0m, 120.0m, 11, "C2", "Available", "C" },
                    { 323, "VIP Section", 15.0m, 120.0m, 11, "C3", "Available", "C" },
                    { 324, "VIP Section", 15.0m, 120.0m, 11, "C4", "Available", "C" },
                    { 325, "VIP Section", 15.0m, 120.0m, 11, "C5", "Available", "C" },
                    { 326, "VIP Section", 15.0m, 120.0m, 11, "C6", "Available", "C" },
                    { 327, "VIP Section", 15.0m, 120.0m, 11, "C7", "Available", "C" },
                    { 328, "VIP Section", 15.0m, 120.0m, 11, "C8", "Available", "C" },
                    { 329, "VIP Section", 15.0m, 120.0m, 11, "C9", "Available", "C" },
                    { 330, "VIP Section", 15.0m, 120.0m, 11, "C10", "Available", "C" },
                    { 331, "Ground Floor", 5.0m, 50.0m, 12, "A1", "Available", "A" },
                    { 332, "Ground Floor", 5.0m, 50.0m, 12, "A2", "Available", "A" },
                    { 333, "Ground Floor", 5.0m, 50.0m, 12, "A3", "Available", "A" },
                    { 334, "Ground Floor", 5.0m, 50.0m, 12, "A4", "Available", "A" },
                    { 335, "Ground Floor", 5.0m, 50.0m, 12, "A5", "Available", "A" },
                    { 336, "Ground Floor", 5.0m, 50.0m, 12, "A6", "Available", "A" },
                    { 337, "Ground Floor", 5.0m, 50.0m, 12, "A7", "Available", "A" },
                    { 338, "Ground Floor", 5.0m, 50.0m, 12, "A8", "Available", "A" },
                    { 339, "Ground Floor", 5.0m, 50.0m, 12, "A9", "Available", "A" },
                    { 340, "Ground Floor", 5.0m, 50.0m, 12, "A10", "Available", "A" },
                    { 341, "First Floor", 10.0m, 80.0m, 12, "B1", "Available", "B" },
                    { 342, "First Floor", 10.0m, 80.0m, 12, "B2", "Available", "B" },
                    { 343, "First Floor", 10.0m, 80.0m, 12, "B3", "Available", "B" },
                    { 344, "First Floor", 10.0m, 80.0m, 12, "B4", "Available", "B" },
                    { 345, "First Floor", 10.0m, 80.0m, 12, "B5", "Available", "B" },
                    { 346, "First Floor", 10.0m, 80.0m, 12, "B6", "Available", "B" },
                    { 347, "First Floor", 10.0m, 80.0m, 12, "B7", "Available", "B" },
                    { 348, "First Floor", 10.0m, 80.0m, 12, "B8", "Available", "B" },
                    { 349, "First Floor", 10.0m, 80.0m, 12, "B9", "Available", "B" },
                    { 350, "First Floor", 10.0m, 80.0m, 12, "B10", "Available", "B" },
                    { 351, "VIP Section", 15.0m, 120.0m, 12, "C1", "Available", "C" },
                    { 352, "VIP Section", 15.0m, 120.0m, 12, "C2", "Available", "C" },
                    { 353, "VIP Section", 15.0m, 120.0m, 12, "C3", "Available", "C" },
                    { 354, "VIP Section", 15.0m, 120.0m, 12, "C4", "Available", "C" },
                    { 355, "VIP Section", 15.0m, 120.0m, 12, "C5", "Available", "C" },
                    { 356, "VIP Section", 15.0m, 120.0m, 12, "C6", "Available", "C" },
                    { 357, "VIP Section", 15.0m, 120.0m, 12, "C7", "Available", "C" },
                    { 358, "VIP Section", 15.0m, 120.0m, 12, "C8", "Available", "C" },
                    { 359, "VIP Section", 15.0m, 120.0m, 12, "C9", "Available", "C" },
                    { 360, "VIP Section", 15.0m, 120.0m, 12, "C10", "Available", "C" },
                    { 361, "Ground Floor", 5.0m, 50.0m, 13, "A1", "Available", "A" },
                    { 362, "Ground Floor", 5.0m, 50.0m, 13, "A2", "Available", "A" },
                    { 363, "Ground Floor", 5.0m, 50.0m, 13, "A3", "Available", "A" },
                    { 364, "Ground Floor", 5.0m, 50.0m, 13, "A4", "Available", "A" },
                    { 365, "Ground Floor", 5.0m, 50.0m, 13, "A5", "Available", "A" },
                    { 366, "Ground Floor", 5.0m, 50.0m, 13, "A6", "Available", "A" },
                    { 367, "Ground Floor", 5.0m, 50.0m, 13, "A7", "Available", "A" },
                    { 368, "Ground Floor", 5.0m, 50.0m, 13, "A8", "Available", "A" },
                    { 369, "Ground Floor", 5.0m, 50.0m, 13, "A9", "Available", "A" },
                    { 370, "Ground Floor", 5.0m, 50.0m, 13, "A10", "Available", "A" },
                    { 371, "First Floor", 10.0m, 80.0m, 13, "B1", "Available", "B" },
                    { 372, "First Floor", 10.0m, 80.0m, 13, "B2", "Available", "B" },
                    { 373, "First Floor", 10.0m, 80.0m, 13, "B3", "Available", "B" },
                    { 374, "First Floor", 10.0m, 80.0m, 13, "B4", "Available", "B" },
                    { 375, "First Floor", 10.0m, 80.0m, 13, "B5", "Available", "B" },
                    { 376, "First Floor", 10.0m, 80.0m, 13, "B6", "Available", "B" },
                    { 377, "First Floor", 10.0m, 80.0m, 13, "B7", "Available", "B" },
                    { 378, "First Floor", 10.0m, 80.0m, 13, "B8", "Available", "B" },
                    { 379, "First Floor", 10.0m, 80.0m, 13, "B9", "Available", "B" },
                    { 380, "First Floor", 10.0m, 80.0m, 13, "B10", "Available", "B" },
                    { 381, "VIP Section", 15.0m, 120.0m, 13, "C1", "Available", "C" },
                    { 382, "VIP Section", 15.0m, 120.0m, 13, "C2", "Available", "C" },
                    { 383, "VIP Section", 15.0m, 120.0m, 13, "C3", "Available", "C" },
                    { 384, "VIP Section", 15.0m, 120.0m, 13, "C4", "Available", "C" },
                    { 385, "VIP Section", 15.0m, 120.0m, 13, "C5", "Available", "C" },
                    { 386, "VIP Section", 15.0m, 120.0m, 13, "C6", "Available", "C" },
                    { 387, "VIP Section", 15.0m, 120.0m, 13, "C7", "Available", "C" },
                    { 388, "VIP Section", 15.0m, 120.0m, 13, "C8", "Available", "C" },
                    { 389, "VIP Section", 15.0m, 120.0m, 13, "C9", "Available", "C" },
                    { 390, "VIP Section", 15.0m, 120.0m, 13, "C10", "Available", "C" },
                    { 391, "Ground Floor", 5.0m, 50.0m, 14, "A1", "Available", "A" },
                    { 392, "Ground Floor", 5.0m, 50.0m, 14, "A2", "Available", "A" },
                    { 393, "Ground Floor", 5.0m, 50.0m, 14, "A3", "Available", "A" },
                    { 394, "Ground Floor", 5.0m, 50.0m, 14, "A4", "Available", "A" },
                    { 395, "Ground Floor", 5.0m, 50.0m, 14, "A5", "Available", "A" },
                    { 396, "Ground Floor", 5.0m, 50.0m, 14, "A6", "Available", "A" },
                    { 397, "Ground Floor", 5.0m, 50.0m, 14, "A7", "Available", "A" },
                    { 398, "Ground Floor", 5.0m, 50.0m, 14, "A8", "Available", "A" },
                    { 399, "Ground Floor", 5.0m, 50.0m, 14, "A9", "Available", "A" },
                    { 400, "Ground Floor", 5.0m, 50.0m, 14, "A10", "Available", "A" },
                    { 401, "First Floor", 10.0m, 80.0m, 14, "B1", "Available", "B" },
                    { 402, "First Floor", 10.0m, 80.0m, 14, "B2", "Available", "B" },
                    { 403, "First Floor", 10.0m, 80.0m, 14, "B3", "Available", "B" },
                    { 404, "First Floor", 10.0m, 80.0m, 14, "B4", "Available", "B" },
                    { 405, "First Floor", 10.0m, 80.0m, 14, "B5", "Available", "B" },
                    { 406, "First Floor", 10.0m, 80.0m, 14, "B6", "Available", "B" },
                    { 407, "First Floor", 10.0m, 80.0m, 14, "B7", "Available", "B" },
                    { 408, "First Floor", 10.0m, 80.0m, 14, "B8", "Available", "B" },
                    { 409, "First Floor", 10.0m, 80.0m, 14, "B9", "Available", "B" },
                    { 410, "First Floor", 10.0m, 80.0m, 14, "B10", "Available", "B" },
                    { 411, "VIP Section", 15.0m, 120.0m, 14, "C1", "Available", "C" },
                    { 412, "VIP Section", 15.0m, 120.0m, 14, "C2", "Available", "C" },
                    { 413, "VIP Section", 15.0m, 120.0m, 14, "C3", "Available", "C" },
                    { 414, "VIP Section", 15.0m, 120.0m, 14, "C4", "Available", "C" },
                    { 415, "VIP Section", 15.0m, 120.0m, 14, "C5", "Available", "C" },
                    { 416, "VIP Section", 15.0m, 120.0m, 14, "C6", "Available", "C" },
                    { 417, "VIP Section", 15.0m, 120.0m, 14, "C7", "Available", "C" },
                    { 418, "VIP Section", 15.0m, 120.0m, 14, "C8", "Available", "C" },
                    { 419, "VIP Section", 15.0m, 120.0m, 14, "C9", "Available", "C" },
                    { 420, "VIP Section", 15.0m, 120.0m, 14, "C10", "Available", "C" },
                    { 421, "Ground Floor", 5.0m, 50.0m, 15, "A1", "Available", "A" },
                    { 422, "Ground Floor", 5.0m, 50.0m, 15, "A2", "Available", "A" },
                    { 423, "Ground Floor", 5.0m, 50.0m, 15, "A3", "Available", "A" },
                    { 424, "Ground Floor", 5.0m, 50.0m, 15, "A4", "Available", "A" },
                    { 425, "Ground Floor", 5.0m, 50.0m, 15, "A5", "Available", "A" },
                    { 426, "Ground Floor", 5.0m, 50.0m, 15, "A6", "Available", "A" },
                    { 427, "Ground Floor", 5.0m, 50.0m, 15, "A7", "Available", "A" },
                    { 428, "Ground Floor", 5.0m, 50.0m, 15, "A8", "Available", "A" },
                    { 429, "Ground Floor", 5.0m, 50.0m, 15, "A9", "Available", "A" },
                    { 430, "Ground Floor", 5.0m, 50.0m, 15, "A10", "Available", "A" },
                    { 431, "First Floor", 10.0m, 80.0m, 15, "B1", "Available", "B" },
                    { 432, "First Floor", 10.0m, 80.0m, 15, "B2", "Available", "B" },
                    { 433, "First Floor", 10.0m, 80.0m, 15, "B3", "Available", "B" },
                    { 434, "First Floor", 10.0m, 80.0m, 15, "B4", "Available", "B" },
                    { 435, "First Floor", 10.0m, 80.0m, 15, "B5", "Available", "B" },
                    { 436, "First Floor", 10.0m, 80.0m, 15, "B6", "Available", "B" },
                    { 437, "First Floor", 10.0m, 80.0m, 15, "B7", "Available", "B" },
                    { 438, "First Floor", 10.0m, 80.0m, 15, "B8", "Available", "B" },
                    { 439, "First Floor", 10.0m, 80.0m, 15, "B9", "Available", "B" },
                    { 440, "First Floor", 10.0m, 80.0m, 15, "B10", "Available", "B" },
                    { 441, "VIP Section", 15.0m, 120.0m, 15, "C1", "Available", "C" },
                    { 442, "VIP Section", 15.0m, 120.0m, 15, "C2", "Available", "C" },
                    { 443, "VIP Section", 15.0m, 120.0m, 15, "C3", "Available", "C" },
                    { 444, "VIP Section", 15.0m, 120.0m, 15, "C4", "Available", "C" },
                    { 445, "VIP Section", 15.0m, 120.0m, 15, "C5", "Available", "C" },
                    { 446, "VIP Section", 15.0m, 120.0m, 15, "C6", "Available", "C" },
                    { 447, "VIP Section", 15.0m, 120.0m, 15, "C7", "Available", "C" },
                    { 448, "VIP Section", 15.0m, 120.0m, 15, "C8", "Available", "C" },
                    { 449, "VIP Section", 15.0m, 120.0m, 15, "C9", "Available", "C" },
                    { 450, "VIP Section", 15.0m, 120.0m, 15, "C10", "Available", "C" },
                    { 451, "Ground Floor", 5.0m, 50.0m, 16, "A1", "Available", "A" },
                    { 452, "Ground Floor", 5.0m, 50.0m, 16, "A2", "Available", "A" },
                    { 453, "Ground Floor", 5.0m, 50.0m, 16, "A3", "Available", "A" },
                    { 454, "Ground Floor", 5.0m, 50.0m, 16, "A4", "Available", "A" },
                    { 455, "Ground Floor", 5.0m, 50.0m, 16, "A5", "Available", "A" },
                    { 456, "Ground Floor", 5.0m, 50.0m, 16, "A6", "Available", "A" },
                    { 457, "Ground Floor", 5.0m, 50.0m, 16, "A7", "Available", "A" },
                    { 458, "Ground Floor", 5.0m, 50.0m, 16, "A8", "Available", "A" },
                    { 459, "Ground Floor", 5.0m, 50.0m, 16, "A9", "Available", "A" },
                    { 460, "Ground Floor", 5.0m, 50.0m, 16, "A10", "Available", "A" },
                    { 461, "First Floor", 10.0m, 80.0m, 16, "B1", "Available", "B" },
                    { 462, "First Floor", 10.0m, 80.0m, 16, "B2", "Available", "B" },
                    { 463, "First Floor", 10.0m, 80.0m, 16, "B3", "Available", "B" },
                    { 464, "First Floor", 10.0m, 80.0m, 16, "B4", "Available", "B" },
                    { 465, "First Floor", 10.0m, 80.0m, 16, "B5", "Available", "B" },
                    { 466, "First Floor", 10.0m, 80.0m, 16, "B6", "Available", "B" },
                    { 467, "First Floor", 10.0m, 80.0m, 16, "B7", "Available", "B" },
                    { 468, "First Floor", 10.0m, 80.0m, 16, "B8", "Available", "B" },
                    { 469, "First Floor", 10.0m, 80.0m, 16, "B9", "Available", "B" },
                    { 470, "First Floor", 10.0m, 80.0m, 16, "B10", "Available", "B" },
                    { 471, "VIP Section", 15.0m, 120.0m, 16, "C1", "Available", "C" },
                    { 472, "VIP Section", 15.0m, 120.0m, 16, "C2", "Available", "C" },
                    { 473, "VIP Section", 15.0m, 120.0m, 16, "C3", "Available", "C" },
                    { 474, "VIP Section", 15.0m, 120.0m, 16, "C4", "Available", "C" },
                    { 475, "VIP Section", 15.0m, 120.0m, 16, "C5", "Available", "C" },
                    { 476, "VIP Section", 15.0m, 120.0m, 16, "C6", "Available", "C" },
                    { 477, "VIP Section", 15.0m, 120.0m, 16, "C7", "Available", "C" },
                    { 478, "VIP Section", 15.0m, 120.0m, 16, "C8", "Available", "C" },
                    { 479, "VIP Section", 15.0m, 120.0m, 16, "C9", "Available", "C" },
                    { 480, "VIP Section", 15.0m, 120.0m, 16, "C10", "Available", "C" },
                    { 481, "Ground Floor", 5.0m, 50.0m, 17, "A1", "Available", "A" },
                    { 482, "Ground Floor", 5.0m, 50.0m, 17, "A2", "Available", "A" },
                    { 483, "Ground Floor", 5.0m, 50.0m, 17, "A3", "Available", "A" },
                    { 484, "Ground Floor", 5.0m, 50.0m, 17, "A4", "Available", "A" },
                    { 485, "Ground Floor", 5.0m, 50.0m, 17, "A5", "Available", "A" },
                    { 486, "Ground Floor", 5.0m, 50.0m, 17, "A6", "Available", "A" },
                    { 487, "Ground Floor", 5.0m, 50.0m, 17, "A7", "Available", "A" },
                    { 488, "Ground Floor", 5.0m, 50.0m, 17, "A8", "Available", "A" },
                    { 489, "Ground Floor", 5.0m, 50.0m, 17, "A9", "Available", "A" },
                    { 490, "Ground Floor", 5.0m, 50.0m, 17, "A10", "Available", "A" },
                    { 491, "First Floor", 10.0m, 80.0m, 17, "B1", "Available", "B" },
                    { 492, "First Floor", 10.0m, 80.0m, 17, "B2", "Available", "B" },
                    { 493, "First Floor", 10.0m, 80.0m, 17, "B3", "Available", "B" },
                    { 494, "First Floor", 10.0m, 80.0m, 17, "B4", "Available", "B" },
                    { 495, "First Floor", 10.0m, 80.0m, 17, "B5", "Available", "B" },
                    { 496, "First Floor", 10.0m, 80.0m, 17, "B6", "Available", "B" },
                    { 497, "First Floor", 10.0m, 80.0m, 17, "B7", "Available", "B" },
                    { 498, "First Floor", 10.0m, 80.0m, 17, "B8", "Available", "B" },
                    { 499, "First Floor", 10.0m, 80.0m, 17, "B9", "Available", "B" },
                    { 500, "First Floor", 10.0m, 80.0m, 17, "B10", "Available", "B" },
                    { 501, "VIP Section", 15.0m, 120.0m, 17, "C1", "Available", "C" },
                    { 502, "VIP Section", 15.0m, 120.0m, 17, "C2", "Available", "C" },
                    { 503, "VIP Section", 15.0m, 120.0m, 17, "C3", "Available", "C" },
                    { 504, "VIP Section", 15.0m, 120.0m, 17, "C4", "Available", "C" },
                    { 505, "VIP Section", 15.0m, 120.0m, 17, "C5", "Available", "C" },
                    { 506, "VIP Section", 15.0m, 120.0m, 17, "C6", "Available", "C" },
                    { 507, "VIP Section", 15.0m, 120.0m, 17, "C7", "Available", "C" },
                    { 508, "VIP Section", 15.0m, 120.0m, 17, "C8", "Available", "C" },
                    { 509, "VIP Section", 15.0m, 120.0m, 17, "C9", "Available", "C" },
                    { 510, "VIP Section", 15.0m, 120.0m, 17, "C10", "Available", "C" },
                    { 511, "Ground Floor", 5.0m, 50.0m, 18, "A1", "Available", "A" },
                    { 512, "Ground Floor", 5.0m, 50.0m, 18, "A2", "Available", "A" },
                    { 513, "Ground Floor", 5.0m, 50.0m, 18, "A3", "Available", "A" },
                    { 514, "Ground Floor", 5.0m, 50.0m, 18, "A4", "Available", "A" },
                    { 515, "Ground Floor", 5.0m, 50.0m, 18, "A5", "Available", "A" },
                    { 516, "Ground Floor", 5.0m, 50.0m, 18, "A6", "Available", "A" },
                    { 517, "Ground Floor", 5.0m, 50.0m, 18, "A7", "Available", "A" },
                    { 518, "Ground Floor", 5.0m, 50.0m, 18, "A8", "Available", "A" },
                    { 519, "Ground Floor", 5.0m, 50.0m, 18, "A9", "Available", "A" },
                    { 520, "Ground Floor", 5.0m, 50.0m, 18, "A10", "Available", "A" },
                    { 521, "First Floor", 10.0m, 80.0m, 18, "B1", "Available", "B" },
                    { 522, "First Floor", 10.0m, 80.0m, 18, "B2", "Available", "B" },
                    { 523, "First Floor", 10.0m, 80.0m, 18, "B3", "Available", "B" },
                    { 524, "First Floor", 10.0m, 80.0m, 18, "B4", "Available", "B" },
                    { 525, "First Floor", 10.0m, 80.0m, 18, "B5", "Available", "B" },
                    { 526, "First Floor", 10.0m, 80.0m, 18, "B6", "Available", "B" },
                    { 527, "First Floor", 10.0m, 80.0m, 18, "B7", "Available", "B" },
                    { 528, "First Floor", 10.0m, 80.0m, 18, "B8", "Available", "B" },
                    { 529, "First Floor", 10.0m, 80.0m, 18, "B9", "Available", "B" },
                    { 530, "First Floor", 10.0m, 80.0m, 18, "B10", "Available", "B" },
                    { 531, "VIP Section", 15.0m, 120.0m, 18, "C1", "Available", "C" },
                    { 532, "VIP Section", 15.0m, 120.0m, 18, "C2", "Available", "C" },
                    { 533, "VIP Section", 15.0m, 120.0m, 18, "C3", "Available", "C" },
                    { 534, "VIP Section", 15.0m, 120.0m, 18, "C4", "Available", "C" },
                    { 535, "VIP Section", 15.0m, 120.0m, 18, "C5", "Available", "C" },
                    { 536, "VIP Section", 15.0m, 120.0m, 18, "C6", "Available", "C" },
                    { 537, "VIP Section", 15.0m, 120.0m, 18, "C7", "Available", "C" },
                    { 538, "VIP Section", 15.0m, 120.0m, 18, "C8", "Available", "C" },
                    { 539, "VIP Section", 15.0m, 120.0m, 18, "C9", "Available", "C" },
                    { 540, "VIP Section", 15.0m, 120.0m, 18, "C10", "Available", "C" },
                    { 541, "Ground Floor", 5.0m, 50.0m, 19, "A1", "Available", "A" },
                    { 542, "Ground Floor", 5.0m, 50.0m, 19, "A2", "Available", "A" },
                    { 543, "Ground Floor", 5.0m, 50.0m, 19, "A3", "Available", "A" },
                    { 544, "Ground Floor", 5.0m, 50.0m, 19, "A4", "Available", "A" },
                    { 545, "Ground Floor", 5.0m, 50.0m, 19, "A5", "Available", "A" },
                    { 546, "Ground Floor", 5.0m, 50.0m, 19, "A6", "Available", "A" },
                    { 547, "Ground Floor", 5.0m, 50.0m, 19, "A7", "Available", "A" },
                    { 548, "Ground Floor", 5.0m, 50.0m, 19, "A8", "Available", "A" },
                    { 549, "Ground Floor", 5.0m, 50.0m, 19, "A9", "Available", "A" },
                    { 550, "Ground Floor", 5.0m, 50.0m, 19, "A10", "Available", "A" },
                    { 551, "First Floor", 10.0m, 80.0m, 19, "B1", "Available", "B" },
                    { 552, "First Floor", 10.0m, 80.0m, 19, "B2", "Available", "B" },
                    { 553, "First Floor", 10.0m, 80.0m, 19, "B3", "Available", "B" },
                    { 554, "First Floor", 10.0m, 80.0m, 19, "B4", "Available", "B" },
                    { 555, "First Floor", 10.0m, 80.0m, 19, "B5", "Available", "B" },
                    { 556, "First Floor", 10.0m, 80.0m, 19, "B6", "Available", "B" },
                    { 557, "First Floor", 10.0m, 80.0m, 19, "B7", "Available", "B" },
                    { 558, "First Floor", 10.0m, 80.0m, 19, "B8", "Available", "B" },
                    { 559, "First Floor", 10.0m, 80.0m, 19, "B9", "Available", "B" },
                    { 560, "First Floor", 10.0m, 80.0m, 19, "B10", "Available", "B" },
                    { 561, "VIP Section", 15.0m, 120.0m, 19, "C1", "Available", "C" },
                    { 562, "VIP Section", 15.0m, 120.0m, 19, "C2", "Available", "C" },
                    { 563, "VIP Section", 15.0m, 120.0m, 19, "C3", "Available", "C" },
                    { 564, "VIP Section", 15.0m, 120.0m, 19, "C4", "Available", "C" },
                    { 565, "VIP Section", 15.0m, 120.0m, 19, "C5", "Available", "C" },
                    { 566, "VIP Section", 15.0m, 120.0m, 19, "C6", "Available", "C" },
                    { 567, "VIP Section", 15.0m, 120.0m, 19, "C7", "Available", "C" },
                    { 568, "VIP Section", 15.0m, 120.0m, 19, "C8", "Available", "C" },
                    { 569, "VIP Section", 15.0m, 120.0m, 19, "C9", "Available", "C" },
                    { 570, "VIP Section", 15.0m, 120.0m, 19, "C10", "Available", "C" },
                    { 571, "Ground Floor", 5.0m, 50.0m, 20, "A1", "Available", "A" },
                    { 572, "Ground Floor", 5.0m, 50.0m, 20, "A2", "Available", "A" },
                    { 573, "Ground Floor", 5.0m, 50.0m, 20, "A3", "Available", "A" },
                    { 574, "Ground Floor", 5.0m, 50.0m, 20, "A4", "Available", "A" },
                    { 575, "Ground Floor", 5.0m, 50.0m, 20, "A5", "Available", "A" },
                    { 576, "Ground Floor", 5.0m, 50.0m, 20, "A6", "Available", "A" },
                    { 577, "Ground Floor", 5.0m, 50.0m, 20, "A7", "Available", "A" },
                    { 578, "Ground Floor", 5.0m, 50.0m, 20, "A8", "Available", "A" },
                    { 579, "Ground Floor", 5.0m, 50.0m, 20, "A9", "Available", "A" },
                    { 580, "Ground Floor", 5.0m, 50.0m, 20, "A10", "Available", "A" },
                    { 581, "First Floor", 10.0m, 80.0m, 20, "B1", "Available", "B" },
                    { 582, "First Floor", 10.0m, 80.0m, 20, "B2", "Available", "B" },
                    { 583, "First Floor", 10.0m, 80.0m, 20, "B3", "Available", "B" },
                    { 584, "First Floor", 10.0m, 80.0m, 20, "B4", "Available", "B" },
                    { 585, "First Floor", 10.0m, 80.0m, 20, "B5", "Available", "B" },
                    { 586, "First Floor", 10.0m, 80.0m, 20, "B6", "Available", "B" },
                    { 587, "First Floor", 10.0m, 80.0m, 20, "B7", "Available", "B" },
                    { 588, "First Floor", 10.0m, 80.0m, 20, "B8", "Available", "B" },
                    { 589, "First Floor", 10.0m, 80.0m, 20, "B9", "Available", "B" },
                    { 590, "First Floor", 10.0m, 80.0m, 20, "B10", "Available", "B" },
                    { 591, "VIP Section", 15.0m, 120.0m, 20, "C1", "Available", "C" },
                    { 592, "VIP Section", 15.0m, 120.0m, 20, "C2", "Available", "C" },
                    { 593, "VIP Section", 15.0m, 120.0m, 20, "C3", "Available", "C" },
                    { 594, "VIP Section", 15.0m, 120.0m, 20, "C4", "Available", "C" },
                    { 595, "VIP Section", 15.0m, 120.0m, 20, "C5", "Available", "C" },
                    { 596, "VIP Section", 15.0m, 120.0m, 20, "C6", "Available", "C" },
                    { 597, "VIP Section", 15.0m, 120.0m, 20, "C7", "Available", "C" },
                    { 598, "VIP Section", 15.0m, 120.0m, 20, "C8", "Available", "C" },
                    { 599, "VIP Section", 15.0m, 120.0m, 20, "C9", "Available", "C" },
                    { 600, "VIP Section", 15.0m, 120.0m, 20, "C10", "Available", "C" },
                    { 601, "Ground Floor", 5.0m, 50.0m, 21, "A1", "Available", "A" },
                    { 602, "Ground Floor", 5.0m, 50.0m, 21, "A2", "Available", "A" },
                    { 603, "Ground Floor", 5.0m, 50.0m, 21, "A3", "Available", "A" },
                    { 604, "Ground Floor", 5.0m, 50.0m, 21, "A4", "Available", "A" },
                    { 605, "Ground Floor", 5.0m, 50.0m, 21, "A5", "Available", "A" },
                    { 606, "Ground Floor", 5.0m, 50.0m, 21, "A6", "Available", "A" },
                    { 607, "Ground Floor", 5.0m, 50.0m, 21, "A7", "Available", "A" },
                    { 608, "Ground Floor", 5.0m, 50.0m, 21, "A8", "Available", "A" },
                    { 609, "Ground Floor", 5.0m, 50.0m, 21, "A9", "Available", "A" },
                    { 610, "Ground Floor", 5.0m, 50.0m, 21, "A10", "Available", "A" },
                    { 611, "First Floor", 10.0m, 80.0m, 21, "B1", "Available", "B" },
                    { 612, "First Floor", 10.0m, 80.0m, 21, "B2", "Available", "B" },
                    { 613, "First Floor", 10.0m, 80.0m, 21, "B3", "Available", "B" },
                    { 614, "First Floor", 10.0m, 80.0m, 21, "B4", "Available", "B" },
                    { 615, "First Floor", 10.0m, 80.0m, 21, "B5", "Available", "B" },
                    { 616, "First Floor", 10.0m, 80.0m, 21, "B6", "Available", "B" },
                    { 617, "First Floor", 10.0m, 80.0m, 21, "B7", "Available", "B" },
                    { 618, "First Floor", 10.0m, 80.0m, 21, "B8", "Available", "B" },
                    { 619, "First Floor", 10.0m, 80.0m, 21, "B9", "Available", "B" },
                    { 620, "First Floor", 10.0m, 80.0m, 21, "B10", "Available", "B" },
                    { 621, "VIP Section", 15.0m, 120.0m, 21, "C1", "Available", "C" },
                    { 622, "VIP Section", 15.0m, 120.0m, 21, "C2", "Available", "C" },
                    { 623, "VIP Section", 15.0m, 120.0m, 21, "C3", "Available", "C" },
                    { 624, "VIP Section", 15.0m, 120.0m, 21, "C4", "Available", "C" },
                    { 625, "VIP Section", 15.0m, 120.0m, 21, "C5", "Available", "C" },
                    { 626, "VIP Section", 15.0m, 120.0m, 21, "C6", "Available", "C" },
                    { 627, "VIP Section", 15.0m, 120.0m, 21, "C7", "Available", "C" },
                    { 628, "VIP Section", 15.0m, 120.0m, 21, "C8", "Available", "C" },
                    { 629, "VIP Section", 15.0m, 120.0m, 21, "C9", "Available", "C" },
                    { 630, "VIP Section", 15.0m, 120.0m, 21, "C10", "Available", "C" },
                    { 631, "Ground Floor", 5.0m, 50.0m, 22, "A1", "Available", "A" },
                    { 632, "Ground Floor", 5.0m, 50.0m, 22, "A2", "Available", "A" },
                    { 633, "Ground Floor", 5.0m, 50.0m, 22, "A3", "Available", "A" },
                    { 634, "Ground Floor", 5.0m, 50.0m, 22, "A4", "Available", "A" },
                    { 635, "Ground Floor", 5.0m, 50.0m, 22, "A5", "Available", "A" },
                    { 636, "Ground Floor", 5.0m, 50.0m, 22, "A6", "Available", "A" },
                    { 637, "Ground Floor", 5.0m, 50.0m, 22, "A7", "Available", "A" },
                    { 638, "Ground Floor", 5.0m, 50.0m, 22, "A8", "Available", "A" },
                    { 639, "Ground Floor", 5.0m, 50.0m, 22, "A9", "Available", "A" },
                    { 640, "Ground Floor", 5.0m, 50.0m, 22, "A10", "Available", "A" },
                    { 641, "First Floor", 10.0m, 80.0m, 22, "B1", "Available", "B" },
                    { 642, "First Floor", 10.0m, 80.0m, 22, "B2", "Available", "B" },
                    { 643, "First Floor", 10.0m, 80.0m, 22, "B3", "Available", "B" },
                    { 644, "First Floor", 10.0m, 80.0m, 22, "B4", "Available", "B" },
                    { 645, "First Floor", 10.0m, 80.0m, 22, "B5", "Available", "B" },
                    { 646, "First Floor", 10.0m, 80.0m, 22, "B6", "Available", "B" },
                    { 647, "First Floor", 10.0m, 80.0m, 22, "B7", "Available", "B" },
                    { 648, "First Floor", 10.0m, 80.0m, 22, "B8", "Available", "B" },
                    { 649, "First Floor", 10.0m, 80.0m, 22, "B9", "Available", "B" },
                    { 650, "First Floor", 10.0m, 80.0m, 22, "B10", "Available", "B" },
                    { 651, "VIP Section", 15.0m, 120.0m, 22, "C1", "Available", "C" },
                    { 652, "VIP Section", 15.0m, 120.0m, 22, "C2", "Available", "C" },
                    { 653, "VIP Section", 15.0m, 120.0m, 22, "C3", "Available", "C" },
                    { 654, "VIP Section", 15.0m, 120.0m, 22, "C4", "Available", "C" },
                    { 655, "VIP Section", 15.0m, 120.0m, 22, "C5", "Available", "C" },
                    { 656, "VIP Section", 15.0m, 120.0m, 22, "C6", "Available", "C" },
                    { 657, "VIP Section", 15.0m, 120.0m, 22, "C7", "Available", "C" },
                    { 658, "VIP Section", 15.0m, 120.0m, 22, "C8", "Available", "C" },
                    { 659, "VIP Section", 15.0m, 120.0m, 22, "C9", "Available", "C" },
                    { 660, "VIP Section", 15.0m, 120.0m, 22, "C10", "Available", "C" },
                    { 661, "Ground Floor", 5.0m, 50.0m, 23, "A1", "Available", "A" },
                    { 662, "Ground Floor", 5.0m, 50.0m, 23, "A2", "Available", "A" },
                    { 663, "Ground Floor", 5.0m, 50.0m, 23, "A3", "Available", "A" },
                    { 664, "Ground Floor", 5.0m, 50.0m, 23, "A4", "Available", "A" },
                    { 665, "Ground Floor", 5.0m, 50.0m, 23, "A5", "Available", "A" },
                    { 666, "Ground Floor", 5.0m, 50.0m, 23, "A6", "Available", "A" },
                    { 667, "Ground Floor", 5.0m, 50.0m, 23, "A7", "Available", "A" },
                    { 668, "Ground Floor", 5.0m, 50.0m, 23, "A8", "Available", "A" },
                    { 669, "Ground Floor", 5.0m, 50.0m, 23, "A9", "Available", "A" },
                    { 670, "Ground Floor", 5.0m, 50.0m, 23, "A10", "Available", "A" },
                    { 671, "First Floor", 10.0m, 80.0m, 23, "B1", "Available", "B" },
                    { 672, "First Floor", 10.0m, 80.0m, 23, "B2", "Available", "B" },
                    { 673, "First Floor", 10.0m, 80.0m, 23, "B3", "Available", "B" },
                    { 674, "First Floor", 10.0m, 80.0m, 23, "B4", "Available", "B" },
                    { 675, "First Floor", 10.0m, 80.0m, 23, "B5", "Available", "B" },
                    { 676, "First Floor", 10.0m, 80.0m, 23, "B6", "Available", "B" },
                    { 677, "First Floor", 10.0m, 80.0m, 23, "B7", "Available", "B" },
                    { 678, "First Floor", 10.0m, 80.0m, 23, "B8", "Available", "B" },
                    { 679, "First Floor", 10.0m, 80.0m, 23, "B9", "Available", "B" },
                    { 680, "First Floor", 10.0m, 80.0m, 23, "B10", "Available", "B" },
                    { 681, "VIP Section", 15.0m, 120.0m, 23, "C1", "Available", "C" },
                    { 682, "VIP Section", 15.0m, 120.0m, 23, "C2", "Available", "C" },
                    { 683, "VIP Section", 15.0m, 120.0m, 23, "C3", "Available", "C" },
                    { 684, "VIP Section", 15.0m, 120.0m, 23, "C4", "Available", "C" },
                    { 685, "VIP Section", 15.0m, 120.0m, 23, "C5", "Available", "C" },
                    { 686, "VIP Section", 15.0m, 120.0m, 23, "C6", "Available", "C" },
                    { 687, "VIP Section", 15.0m, 120.0m, 23, "C7", "Available", "C" },
                    { 688, "VIP Section", 15.0m, 120.0m, 23, "C8", "Available", "C" },
                    { 689, "VIP Section", 15.0m, 120.0m, 23, "C9", "Available", "C" },
                    { 690, "VIP Section", 15.0m, 120.0m, 23, "C10", "Available", "C" },
                    { 691, "Ground Floor", 5.0m, 50.0m, 24, "A1", "Available", "A" },
                    { 692, "Ground Floor", 5.0m, 50.0m, 24, "A2", "Available", "A" },
                    { 693, "Ground Floor", 5.0m, 50.0m, 24, "A3", "Available", "A" },
                    { 694, "Ground Floor", 5.0m, 50.0m, 24, "A4", "Available", "A" },
                    { 695, "Ground Floor", 5.0m, 50.0m, 24, "A5", "Available", "A" },
                    { 696, "Ground Floor", 5.0m, 50.0m, 24, "A6", "Available", "A" },
                    { 697, "Ground Floor", 5.0m, 50.0m, 24, "A7", "Available", "A" },
                    { 698, "Ground Floor", 5.0m, 50.0m, 24, "A8", "Available", "A" },
                    { 699, "Ground Floor", 5.0m, 50.0m, 24, "A9", "Available", "A" },
                    { 700, "Ground Floor", 5.0m, 50.0m, 24, "A10", "Available", "A" },
                    { 701, "First Floor", 10.0m, 80.0m, 24, "B1", "Available", "B" },
                    { 702, "First Floor", 10.0m, 80.0m, 24, "B2", "Available", "B" },
                    { 703, "First Floor", 10.0m, 80.0m, 24, "B3", "Available", "B" },
                    { 704, "First Floor", 10.0m, 80.0m, 24, "B4", "Available", "B" },
                    { 705, "First Floor", 10.0m, 80.0m, 24, "B5", "Available", "B" },
                    { 706, "First Floor", 10.0m, 80.0m, 24, "B6", "Available", "B" },
                    { 707, "First Floor", 10.0m, 80.0m, 24, "B7", "Available", "B" },
                    { 708, "First Floor", 10.0m, 80.0m, 24, "B8", "Available", "B" },
                    { 709, "First Floor", 10.0m, 80.0m, 24, "B9", "Available", "B" },
                    { 710, "First Floor", 10.0m, 80.0m, 24, "B10", "Available", "B" },
                    { 711, "VIP Section", 15.0m, 120.0m, 24, "C1", "Available", "C" },
                    { 712, "VIP Section", 15.0m, 120.0m, 24, "C2", "Available", "C" },
                    { 713, "VIP Section", 15.0m, 120.0m, 24, "C3", "Available", "C" },
                    { 714, "VIP Section", 15.0m, 120.0m, 24, "C4", "Available", "C" },
                    { 715, "VIP Section", 15.0m, 120.0m, 24, "C5", "Available", "C" },
                    { 716, "VIP Section", 15.0m, 120.0m, 24, "C6", "Available", "C" },
                    { 717, "VIP Section", 15.0m, 120.0m, 24, "C7", "Available", "C" },
                    { 718, "VIP Section", 15.0m, 120.0m, 24, "C8", "Available", "C" },
                    { 719, "VIP Section", 15.0m, 120.0m, 24, "C9", "Available", "C" },
                    { 720, "VIP Section", 15.0m, 120.0m, 24, "C10", "Available", "C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 617);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 618);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 619);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 629);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 631);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 632);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 633);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 636);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 637);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 639);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 640);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 647);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 648);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 649);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 650);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 651);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 653);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 656);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 657);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 661);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 669);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 671);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 672);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 673);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 675);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 676);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 677);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 680);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 683);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 684);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 685);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 687);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 689);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 692);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 696);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 697);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 699);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 713);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 714);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 715);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 716);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 717);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 718);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 719);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "Id",
                keyValue: 720);
        }
    }
}
