using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }

    [Column(TypeName = "decimal(16, 4)")]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public List<ProductImages> ProductImages { get; set; } = [];
    public List<ProductCarGeneration> ProductCarGenerations { get; set; } = [];
    public List<ProductBought> ProductsBought { get; set; } = [];
    public List<ProductOrder> ProductOrders { get; set; } = [];
    public List<ServiceProductOrder> ServiceProductOrders { get; set; } = [];

    [ForeignKey("CarSectionId")]
    public CarSection CarSection { get; set; } = null!;
    public int CarSectionId { get; set; }

    [ForeignKey("ProductTypeId")]
    public ProductType ProductType { get; set; } = null!;
    public int ProductTypeId { get; set; }

    [ForeignKey("ProductMakerId")]
    public ProductMaker ProductMaker { get; set; } = null!;
    public int ProductMakerId { get; set; }

    [ForeignKey("CountryOfOriginId")]
    public Country CountryOfOrigin { get; set; } = null!;
    public int CountryOfOriginId { get; set; }
}
