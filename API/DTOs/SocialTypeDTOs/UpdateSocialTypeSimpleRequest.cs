namespace API.DTOs.SocialTypeDTOs;

public class UpdateSocialTypeSimpleRequest
{
    public string? Type { get; set; }
    public IFormFile? Logo { get; set; }
}
