using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ProductBought
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(16, 4)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(16, 4)")]
    public decimal UnitDiscount { get; set; }
    public DateOnly BoughtAt { get; set; }
    public string? Notes { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }

    [ForeignKey("ShopId")]
    public Shop Shop { get; set; } = null!;
    public int ShopId { get; set; }
}
