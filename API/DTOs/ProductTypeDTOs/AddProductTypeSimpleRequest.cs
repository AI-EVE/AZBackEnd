using System.ComponentModel.DataAnnotations;

namespace API.DTOs.ProductTypeDTOs;

public class AddProductTypeSimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
}
