using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ShopPhone
{
    [Key]
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = null!;

    [ForeignKey("ShopId")]
    public Shop Shop { get; set; } = null!;
    public int ShopId { get; set; }
}
