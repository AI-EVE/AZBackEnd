using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class ProductMaker
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}
