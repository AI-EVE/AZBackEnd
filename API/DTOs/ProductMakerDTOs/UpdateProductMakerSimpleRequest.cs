using System;

namespace API.DTOs.ProductMakerDTOs;

public class UpdateProductMakerSimpleRequest
{
    public string? Name { get; set; }
    public IFormFile? Logo { get; set; }
}
