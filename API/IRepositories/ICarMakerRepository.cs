using API.DTOs.CarMakerDTOs;
using API.Models;

namespace API.IRepositories;

public interface ICarMakerRepository
{
    Task<IEnumerable<CarMakerSimpleResponse>> GetSimpleCarMakersAsync();
    Task<CarMaker?> GetCarMakerAsync(int id);
    Task<CarMakerFullResponse?> GetFullCarMakerAsync(int id);
    Task<CarMakerSimpleResponse?> AddCarMakerAsync(string name, string logoUrl);
    Task<bool> DeleteCarMakerAsync(CarMaker carMaker);
    Task<bool> SaveChangesAsync();
}
