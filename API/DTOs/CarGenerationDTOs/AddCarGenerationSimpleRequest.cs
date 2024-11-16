using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarGenerationDTOs;

public class AddCarGenerationSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int CarModelId { get; set; }
}
