using API.DTOs.CarSectionDTOs;
using API.Filters;
using API.Models;

namespace API.IRepositories;

public interface ICarSectionRepository
{
    Task<List<CarSectionSimpleResponse>> GetCarSectionsAsync(CarSectionFilters filters);
    Task<CarSection?> GetCarSectionByIdAsync(int id);
    Task<CarSectionSimpleResponse> AddCarSectionAsync(AddCarSectionSimpleRequest carSection);
    Task DeleteCarSectionAsync(CarSection carSection);
    Task<bool> SaveChangesAsync();
}
