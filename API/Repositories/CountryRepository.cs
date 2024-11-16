using API.Data;
using API.DTOs.CountryDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class CountryRepository(ApplicationDbContext context) : ICountryRepository
{
    public async Task<CountrySimpleResponse> AddAsync(Country country)
    {
        await context.Countries.AddAsync(country);

        await context.SaveChangesAsync();

        return new CountrySimpleResponse
        {
            Id = country.Id,
            Name = country.Name,
            FlagUrl = country.FlagUrl
        };
    }

    public async Task DeleteAsync(Country country)
    {
        context.Countries.Remove(country);

        await context.SaveChangesAsync();
    }

    public async Task<List<CountrySimpleResponse>> GetAllAsync()
    {
        var countries = await context.Countries.Select(country => new CountrySimpleResponse
        {
            Id = country.Id,
            Name = country.Name,
            FlagUrl = country.FlagUrl
        }).ToListAsync();

        return countries;
    }

    public async Task<Country?> GetByIdAsync(int id)
    {
        var country = await context.Countries.FindAsync(id);

        return country;
    }

    public async Task<bool> NameExistsAsync(string name)
    {
        return await context.Countries.AnyAsync(country => country.Name == name);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
