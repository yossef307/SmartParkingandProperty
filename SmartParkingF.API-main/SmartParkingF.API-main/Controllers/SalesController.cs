using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartParkingF.API.Data;
using SmartParkingF.API.Models;

namespace SmartParkingF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // الحصول على كل عمليات البيع
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetSales()
        {
            return await _context.Sales
                .Include(s => s.Property)
                .Include(s => s.Buyer)
                .OrderByDescending(s => s.CreatedAt)
                .Select(s => new {
                    s.Id,
                    s.PropertyId,
                    PropertyName = s.Property != null ? s.Property.Name : "N/A",
                    s.BuyerId,
                    BuyerName = s.Buyer != null ? s.Buyer.FullName : "N/A",
                    BuyerEmail = s.Buyer != null ? s.Buyer.Email : "N/A",
                    s.SalePrice,
                    s.PaymentMethod,
                    s.Status,
                    s.CreatedAt,
                    s.CompletedAt
                })
                .ToListAsync();
        }

        // الحصول على مشتريات مستخدم معين
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserPurchases(int userId)
        {
            return await _context.Sales
                .Include(s => s.Property)
                .Where(s => s.BuyerId == userId)
                .OrderByDescending(s => s.CreatedAt)
                .Select(s => new {
                    s.Id,
                    s.PropertyId,
                    PropertyName = s.Property != null ? s.Property.Name : "N/A",
                    PropertyImage = s.Property != null ? s.Property.ImageUrl : "",
                    PropertyLocation = s.Property != null ? s.Property.Location : "N/A",
                    s.SalePrice,
                    s.PaymentMethod,
                    s.Status,
                    s.CreatedAt
                })
                .ToListAsync();
        }

        // شراء عقار
        [HttpPost]
        public async Task<ActionResult> PurchaseProperty([FromBody] SaleDto saleDto)
        {
            if (saleDto == null) return BadRequest(new { message = "Sale data is incomplete." });

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var property = await _context.Properties.FindAsync(saleDto.PropertyId);
                if (property == null)
                    return NotFound(new { success = false, message = "العقار غير موجود" });

                if (property.IsSold)
                    return BadRequest(new { success = false, message = "هذا العقار تم بيعه بالفعل" });

                if (property.ListingType == "Rent")
                    return BadRequest(new { success = false, message = "هذا العقار للإيجار فقط وغير متاح للبيع" });

                var sale = new Sale
                {
                    PropertyId = saleDto.PropertyId,
                    BuyerId = saleDto.BuyerId,
                    SalePrice = property.SalePrice ?? property.Price,
                    PaymentMethod = saleDto.PaymentMethod ?? "Card",
                    Status = "Completed",
                    CreatedAt = DateTime.UtcNow,
                    CompletedAt = DateTime.UtcNow
                };

                // تحديث حالة العقار لـ مباع
                property.IsSold = true;

                _context.Sales.Add(sale);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new
                {
                    success = true,
                    message = "تم الشراء بنجاح! مبروك على عقارك الجديد",
                    saleId = sale.Id
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { success = false, message = "خطأ في قاعدة البيانات", error = ex.Message });
            }
        }

        // إلغاء عملية شراء (للأدمن فقط)
        [HttpDelete("{saleId}")]
        public async Task<IActionResult> CancelSale(int saleId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var sale = await _context.Sales
                    .Include(s => s.Property)
                    .FirstOrDefaultAsync(s => s.Id == saleId);

                if (sale == null)
                    return NotFound(new { message = "Sale not found." });

                // إعادة العقار للبيع
                if (sale.Property != null)
                    sale.Property.IsSold = false;

                sale.Status = "Cancelled";
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { success = true, message = "تم إلغاء عملية البيع" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return BadRequest(new { success = false, message = "خطأ أثناء الإلغاء", error = ex.Message });
            }
        }
    }

    public class SaleDto
    {
        public int PropertyId { get; set; }
        public int BuyerId { get; set; }
        public string? PaymentMethod { get; set; }
    }
}