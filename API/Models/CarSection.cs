using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class CarSection
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Product> Products { get; set; } = [];
    public List<ServiceFee> ServiceFees { get; set; } = [];
}
