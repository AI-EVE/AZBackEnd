using API.DTOs.ProductTypeDTOs;
using API.Models;

namespace API.IRepositories;

public interface IProductTypeRepository
{
    public Task<List<ProductTypeSimpleResponse>> GetAllAsync();
    public Task<ProductType?> GetByIdAsync(int id);
    public Task<ProductTypeSimpleResponse> AddAsync(AddProductTypeSimpleRequest productType);
    public Task DeleteAsync(ProductType productType);

    public Task<bool> SaveChangesAsync();
}
