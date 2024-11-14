using System;

namespace API.DTOs.CarMakerDTOs;

public class CarMakerSimpleResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
}
