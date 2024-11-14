using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class CarGeneration
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Car> Cars { get; set; } = [];
    public List<ProductCarGeneration> ProductCarGenerations { get; set; } = [];

    [ForeignKey("CarModelId")]
    public CarModel CarModel { get; set; } = null!;
    public int CarModelId { get; set; }

}
