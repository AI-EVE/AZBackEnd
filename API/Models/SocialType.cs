using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class SocialType
{
    [Key]
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public List<ClientSocial> ClientSocials { get; set; } = [];
    public List<ShopSocial> ShopSocials { get; set; } = [];
}
