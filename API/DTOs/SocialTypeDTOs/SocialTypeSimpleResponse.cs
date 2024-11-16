using System;

namespace API.DTOs.SocialTypeDTOs;

public class SocialTypeSimpleResponse
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
}
