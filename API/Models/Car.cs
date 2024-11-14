using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Car
{
    [Key]
    public int Id { get; set; }
    public string Color { get; set; } = null!;
    public string Plate { get; set; } = null!;
    public string Vin { get; set; } = null!;
    public string? Notes { get; set; }
    public List<CarImage> CarImages { get; set; } = [];
    public List<Service> Services { get; set; } = [];

    [ForeignKey("CarGenerationId")]
    public CarGeneration CarGeneration { get; set; } = null!;
    public int CarGenerationId { get; set; }

    [ForeignKey("ClientId")]
    public Client Client { get; set; } = null!;
    public int ClientId { get; set; }
}
