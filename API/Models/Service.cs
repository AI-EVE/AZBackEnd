using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Service
{
    [Key]
    public int Id { get; set; }
    public DateOnly ServiceDate { get; set; }
    public string? Notes { get; set; }
    public List<ServiceProductOrder> ServiceProductOrders { get; set; } = [];
    public List<ServiceFee> ServiceFees { get; set; } = [];

    [ForeignKey("ServiceStatusId")]
    public ServiceStatus ServiceStatus { get; set; } = null!;
    public int ServiceStatusId { get; set; }

    [ForeignKey("CarId")]
    public Car Car { get; set; } = null!;
    public int CarId { get; set; }
}
