using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class CarModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<CarGeneration> CarGenerations { get; set; } = [];

    [ForeignKey("CarMakerId")]
    public CarMaker CarMaker { get; set; } = null!;
    public int CarMakerId { get; set; }
}
