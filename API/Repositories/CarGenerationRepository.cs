using API.Data;
using API.DTOs.CarGenerationDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class CarGenerationRepository(ApplicationDbContext context) : ICarGenerationRepository
{
    public async Task<carGenerationSimpleResponse> AddAsync(AddCarGenerationSimpleRequest addCarGenerationSimpleRequest)
    {
        var carGeneration = new CarGeneration
        {
            Name = addCarGenerationSimpleRequest.Name,
            CarModelId = addCarGenerationSimpleRequest.CarModelId
        };

        await context.CarGenerations.AddAsync(carGeneration);
        await context.SaveChangesAsync();
        return new carGenerationSimpleResponse
        {
            Id = carGeneration.Id,
            Name = carGeneration.Name
        };

    }

    public void Delete(CarGeneration carGeneration)
    {
        context.CarGenerations.Remove(carGeneration);
    }


    public async Task<CarGeneration?> GetByIdAsync(int id)
    {
        return await context.CarGenerations.FirstOrDefaultAsync(cm => cm.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
