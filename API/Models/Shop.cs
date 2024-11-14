using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Shop
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? OwnerName { get; set; }
    public string? Notes { get; set; }

    public List<ShopImage> ShopImages { get; set; } = [];
    public List<ShopSocial> ShopSocials { get; set; } = [];
    public List<ShopPhone> ShopPhones { get; set; } = [];
    public List<ShopBillImage> ShopProducts { get; set; } = [];
    public List<ProductBought> ProductsBought { get; set; } = [];
}
