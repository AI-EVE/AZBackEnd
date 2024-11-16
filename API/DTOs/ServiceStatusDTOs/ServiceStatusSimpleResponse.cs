using System;

namespace API.DTOs.ServiceStatusDTOs;

public class ServiceStatusSimpleResponse
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public string Description { get; set; } = null!;
}
