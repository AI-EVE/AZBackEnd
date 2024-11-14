using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarModelDTOs;

public class AddCarModelSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int CarMakerId { get; set; }
}
