using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarMakerDTOs;

public class UpdateCarMakerSimpleRequest
{
    public string? Name { get; set; } = null!;
    public IFormFile? Logo { get; set; } = null!;
}
