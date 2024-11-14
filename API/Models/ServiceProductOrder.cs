using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ServiceProductOrder
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(16, 4)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(16, 4)")]
    public decimal UnitDiscount { get; set; }
    public string? Notes { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }

    [ForeignKey("ServiceId")]
    public Service Service { get; set; } = null!;
    public int ServiceId { get; set; }
}
