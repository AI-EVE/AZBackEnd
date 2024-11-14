using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class CarMaker
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public List<CarModel> CarModels { get; set; } = [];
}
