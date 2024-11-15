using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarSectionDTOs;

public class CarSectionUpdateDto
{
    [Required]
    public string Name { get; set; } = null!;
}
