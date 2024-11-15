using System;
using API.Data;
using API.DTOs.CarSectionDTOs;
using API.Filters;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class CarSectionRepository(ApplicationDbContext context) : ICarSectionRepository
{
    public async Task<CarSection> AddCarSectionAsync(AddCarSectionSimpleRequest carSection)
    {
        var newCarSection = new CarSection
        {
            Name = carSection.Name
        };

        context.CarSections.Add(newCarSection);
        await context.SaveChangesAsync();
        return newCarSection;
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

    public async Task<List<CarSectionSimpleResponse>> GetCarSectionsAsync(CarSectionFilters filters)
    {
        var query = context.CarSections.AsQueryable();
        if (!string.IsNullOrWhiteSpace(filters.Name))
        {
            query = query.Where(cs => cs.Name.Contains(filters.Name));
        }

        return await query.Select(cs => new CarSectionSimpleResponse
        {
            Id = cs.Id,
            Name = cs.Name
        }).ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
