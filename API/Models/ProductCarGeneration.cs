using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ProductCarGeneration
{
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }

    [ForeignKey("CarGenerationId")]
    public CarGeneration CarGeneration { get; set; } = null!;
    public int CarGenerationId { get; set; }
}
