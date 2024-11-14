using API.DTOs.CarGenerationDTOs;
using API.Models;

namespace API.IRepositories;

public interface ICarGenerationRepository
{
    Task<CarGeneration?> GetByIdAsync(int id);
    Task<carGenerationSimpleResponse> AddAsync(AddCarGenerationSimpleRequest addCarModelSimpleRequest);
    Task<bool> SaveChangesAsync();
    void Delete(CarGeneration carModel);
}
