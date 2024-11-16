namespace API.DTOs.CountryDTOs;

public class UpdateCountrySimpleRequest
{
    public string? Name { get; set; }
    public IFormFile? Flag { get; set; }
}
