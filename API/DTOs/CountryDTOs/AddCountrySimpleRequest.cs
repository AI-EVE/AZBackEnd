using System.ComponentModel.DataAnnotations;

namespace API.DTOs.CountryDTOs;

public class AddCountrySimpleRequest
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public IFormFile Flag { get; set; } = null!;
}
