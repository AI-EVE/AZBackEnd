using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class ProductType
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
