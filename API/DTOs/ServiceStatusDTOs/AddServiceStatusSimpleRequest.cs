using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.ServiceStatusDTOs;

public class AddServiceStatusSimpleRequest
{
    [Required]
    public string Status { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
}
