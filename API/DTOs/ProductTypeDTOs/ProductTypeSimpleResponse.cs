using System;

namespace API.DTOs.ProductTypeDTOs;

public class ProductTypeSimpleResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
