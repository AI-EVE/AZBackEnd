using API.DTOs.CarModelDTOs;
using API.Models;

namespace API.IRepositories;

public interface ICarModelRepository
{
    Task<CarModel?> GetByIdAsync(int id);
    Task<CarModelSimpleResponse> AddAsync(AddCarModelSimpleRequest addCarModelSimpleRequest);
    Task<bool> SaveChangesAsync();
    void Delete(CarModel carModel);
}
