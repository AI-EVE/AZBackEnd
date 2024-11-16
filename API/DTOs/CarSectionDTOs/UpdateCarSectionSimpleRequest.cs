using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarSectionDTOs;

public class UpdateCarSectionSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
}
