using System.ComponentModel.DataAnnotations;

namespace API.DTOs.SocialTypeDTOs;

public class AddSocialTypeSimpleRequest
{
    [Required]
    public string Type { get; set; } = null!;
    [Required]
    public IFormFile Logo { get; set; } = null!;
}
