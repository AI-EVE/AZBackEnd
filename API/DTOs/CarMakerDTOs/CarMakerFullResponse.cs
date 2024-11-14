using System;
using System.Linq.Expressions;
using API.Models;

namespace API.DTOs.CarMakerDTOs;

public class CarMakerFullResponse
{
    public static Expression<Func<CarMaker, CarMakerFullResponse>> FromCarMaker()
    {
        return carMaker => new CarMakerFullResponse
        {
            Id = carMaker.Id,
            Name = carMaker.Name,
            LogoUrl = carMaker.LogoUrl,
            CarModels = carMaker.CarModels.Select(cmodel => new CarMakerFullModelResponse
            {
                Id = cmodel.Id,
                Name = cmodel.Name,
                CarGenerations = cmodel.CarGenerations.Select(cgeneration => new CarMakerFullGenerationResponse
                {
                    Id = cgeneration.Id,
                    Name = cgeneration.Name
                }).ToList()
            }).ToList()
        };
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public List<CarMakerFullModelResponse> CarModels { get; set; } = [];
}

public class CarMakerFullModelResponse
{

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<CarMakerFullGenerationResponse> CarGenerations { get; set; } = [];
}

public class CarMakerFullGenerationResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}