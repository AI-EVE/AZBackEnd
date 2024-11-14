using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarMakerDTOs;

public class AddCarMakerSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public IFormFile Logo { get; set; } = null!;
}
