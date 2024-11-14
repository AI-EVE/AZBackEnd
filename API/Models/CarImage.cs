using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class CarImage
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public bool IsMain { get; set; }

    [ForeignKey("CarId")]
    public Car Car { get; set; } = null!;
    public int CarId { get; set; }
}
