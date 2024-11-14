using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ProductImages
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
    public int ProductId { get; set; }
}
