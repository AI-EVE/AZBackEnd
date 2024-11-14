using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Client
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Notes { get; set; }

    public List<ClientImage> ClientImages { get; set; } = [];
    public List<ClientSocial> ClientSocials { get; set; } = [];
    public List<ClientPhone> ClientPhones { get; set; } = [];
    public List<Car> Cars { get; set; } = [];
    public List<ProductOrder> ProductOrders { get; set; } = [];
}
