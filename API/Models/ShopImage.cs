using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ShopImage
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }

    [ForeignKey("ShopId")]
    public Shop Shop { get; set; } = null!;
    public int ShopId { get; set; }
}
