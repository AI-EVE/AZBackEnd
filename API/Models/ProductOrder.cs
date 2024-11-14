using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ProductOrder
{
    [Key]
    public int Id { get; set; }
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(16, 4)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(16, 4)")]

    public decimal UnitDiscount { get; set; }
    public DateOnly OrderedAt { get; set; }
    public bool IsReturned { get; set; }
    public string? Notes { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }

    [ForeignKey("ClientId")]
    public Client Client { get; set; } = null!;
    public int ClientId { get; set; }
}
