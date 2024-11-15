using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarSectionDTOs;

public class AddCarSectionSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
}
