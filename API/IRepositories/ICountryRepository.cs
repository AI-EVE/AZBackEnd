using System;
using API.DTOs.CountryDTOs;
using API.Models;

namespace API.IRepositories;

public interface ICountryRepository
{
    Task<List<CountrySimpleResponse>> GetAllAsync();
    Task<Country?> GetByIdAsync(int id);
    Task<CountrySimpleResponse> AddAsync(Country country);
    Task DeleteAsync(Country country);
    Task<bool> SaveChangesAsync();
}
