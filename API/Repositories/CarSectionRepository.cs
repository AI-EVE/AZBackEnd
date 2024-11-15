using System;
using API.Data;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class CarSectionRepository(ApplicationDbContext context) : ICarSectionRepository
{
    public async Task<CarSection> AddCarSectionAsync(CarSection carSection)
    {
        await context.CarSections.AddAsync(carSection);
        await context.SaveChangesAsync();
        return carSection;
    }

    public async Task<CarSection> DeleteCarSectionAsync(CarSection carSection)
    {
        context.CarSections.Remove(carSection);
        await context.SaveChangesAsync();
        return carSection;
    }

    public async Task<CarSection?> GetCarSectionByIdAsync(int id)
    {
        return await context.CarSections.FirstOrDefaultAsync(cs => cs.Id == id);
    }

    public async Task<IEnumerable<CarSection>> GetCarSectionsAsync()
    {
        return await context.CarSections.ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
