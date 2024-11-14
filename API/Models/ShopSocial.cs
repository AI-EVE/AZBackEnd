using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ShopSocial
{
    [Key]
    public int Id { get; set; }
    public string SocialUrl { get; set; } = null!;

    [ForeignKey("ShopId")]
    public Shop Shop { get; set; } = null!;
    public int ShopId { get; set; }

    [ForeignKey("SocialTypeId")]
    public SocialType SocialType { get; set; } = null!;
    public int SocialTypeId { get; set; }
}
