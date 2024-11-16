using API.DTOs.ProductMakerDTOs;
using API.Models;

namespace API.IRepositories;

public interface IProductMakerRepository
{
    Task<List<ProductMakerSimpleResponse>> GetAllAsync();
    Task<ProductMaker?> GetByIdAsync(int id);
    Task<ProductMakerSimpleResponse> AddAsync(ProductMaker productMaker);
    Task DeleteAsync(ProductMaker productMaker);
    Task<bool> NameExistsAsync(string name);

    Task<bool> SaveChangesAsync();
}
