using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CarModelDTOs;

public class UpdateCarModelSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;

}
