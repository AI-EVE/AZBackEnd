using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.ProductMakerDTOs;

public class AddProductMakerSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public IFormFile Logo { get; set; } = null!;
}
