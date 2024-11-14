using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ClientPhone
{
    [Key]
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey("ClientId")]
    public Client Client { get; set; } = null!;
    public int ClientId { get; set; }
}
