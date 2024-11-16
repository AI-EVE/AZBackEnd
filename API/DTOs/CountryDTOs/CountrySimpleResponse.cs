namespace API.DTOs.CountryDTOs;

public class CountrySimpleResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string FlagUrl { get; set; } = null!;
}
