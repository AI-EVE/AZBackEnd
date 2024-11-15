using System.ComponentModel.DataAnnotations;

namespace API.DTOs.ProductTypeDTOs;

public class UpdateProductTypeSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
}
