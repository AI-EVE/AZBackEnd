using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ClientSocial
{
    [Key]
    public int Id { get; set; }
    public string SocialUrl { get; set; } = null!;

    [ForeignKey("ClientId")]
    public Client Client { get; set; } = null!;
    public int ClientId { get; set; }

    [ForeignKey("SocialTypeId")]
    public SocialType SocialType { get; set; } = null!;
    public int SocialTypeId { get; set; }
}
