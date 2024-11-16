using API.Data;
using API.DTOs.CarModelDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class CarModelRepository(ApplicationDbContext context) : ICarModelRepository
{
    public async Task<CarModelSimpleResponse> AddAsync(AddCarModelSimpleRequest addCarModelSimpleRequest)
    {
        var carModel = new CarModel
        {
            Name = addCarModelSimpleRequest.Name,
            CarMakerId = addCarModelSimpleRequest.CarMakerId
        };

        await context.CarModels.AddAsync(carModel);
        await context.SaveChangesAsync();
        return new CarModelSimpleResponse
        {
            Id = carModel.Id,
            Name = carModel.Name
        };

    }

    public void Delete(CarModel carModel)
    {
        context.CarModels.Remove(carModel);
    }


    public async Task<CarModel?> GetByIdAsync(int id)
    {
        return await context.CarModels.FirstOrDefaultAsync(cm => cm.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
