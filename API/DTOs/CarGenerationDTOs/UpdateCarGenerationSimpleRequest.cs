using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarGenerationDTOs;

public class UpdateCarGenerationSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
}
