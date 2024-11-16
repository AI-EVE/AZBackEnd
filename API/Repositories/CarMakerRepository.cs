using API.Data;
using API.DTOs.CarMakerDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Repositories;

public class CarMakerRepository(ApplicationDbContext context) : ICarMakerRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<CarMakerSimpleResponse>> GetSimpleCarMakersAsync()
    {
        return await _context.CarMakers
            .Select(c => new CarMakerSimpleResponse
            {
                Id = c.Id,
                Name = c.Name,
                LogoUrl = c.LogoUrl
            })
            .ToListAsync();
    }

    public async Task<CarMakerFullResponse?> GetFullCarMakerAsync(int id)
    {
        return await _context.CarMakers
            .Where(c => c.Id == id)
            .Select(CarMakerFullResponse.FromCarMaker())
            .FirstOrDefaultAsync();
    }

    public async Task<CarMaker?> GetCarMakerAsync(int id)
    {
        return await _context.CarMakers.FindAsync(id);
    }

    public async Task<CarMakerSimpleResponse?> AddCarMakerAsync(string name, string logoUrl)
    {
        var carMaker = new CarMaker
        {
            Name = name,
            LogoUrl = logoUrl
        };

        await _context.CarMakers.AddAsync(carMaker);
        try
        {
            var result = await _context.SaveChangesAsync();


            return new CarMakerSimpleResponse
            {
                Id = carMaker.Id,
                Name = carMaker.Name,
                LogoUrl = carMaker.LogoUrl
            };

        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
        {
            return null;
        }
    }

    public async Task<bool> DeleteCarMakerAsync(CarMaker carMaker)
    {

        _context.CarMakers.Remove(carMaker);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
        {
            return false;
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException)
        {
            return false;
        }
    }

    public async Task<bool> NameExistsAsync(string name)
    {
        return await _context.CarMakers.AnyAsync(c => c.Name == name);
    }
}
