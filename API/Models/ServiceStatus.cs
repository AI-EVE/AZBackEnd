using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class ServiceStatus
{
    [Key]
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<Service> Services { get; set; } = [];
}
