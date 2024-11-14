using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ShopBillImage
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public DateOnly TakenAt { get; set; }

    [ForeignKey("ShopId")]
    public Shop Shop { get; set; } = null!;
    public int ShopId { get; set; }
}
