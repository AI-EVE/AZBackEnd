using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ClientImage
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }

    [ForeignKey("ClientId")]
    public Client Client { get; set; } = null!;
    public int ClientId { get; set; }
}
