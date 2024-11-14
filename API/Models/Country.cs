using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Country
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string FlagUrl { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
}