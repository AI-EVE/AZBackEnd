using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ServiceFee
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "decimal(16, 4)")]
    public decimal Fee { get; set; }

    [Column(TypeName = "decimal(16, 4)")]
    public decimal Discount { get; set; }
    public string? Notes { get; set; }

    [ForeignKey("ServiceId")]
    public Service Service { get; set; } = null!;
    public int ServiceId { get; set; }

    [ForeignKey("CarSectionId")]
    public CarSection CarSection { get; set; } = null!;
    public int CarSectionId { get; set; }

}