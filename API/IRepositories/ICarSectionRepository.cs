using System;
using API.Models;

namespace API.IRepositories;

public interface ICarSectionRepository
{
    Task<IEnumerable<CarSection>> GetCarSectionsAsync();
    Task<CarSection?> GetCarSectionByIdAsync(int id);
    Task<CarSection> AddCarSectionAsync(CarSection carSection);
    Task<CarSection> DeleteCarSectionAsync(CarSection carSection);
    Task<bool> SaveChangesAsync();
}
