using API.Data;
using API.DTOs.ProductTypeDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class ProductTypeRepository(ApplicationDbContext context) : IProductTypeRepository
{
    public async Task<ProductTypeSimpleResponse> AddAsync(AddProductTypeSimpleRequest productType)
    {
        var newProductType = new ProductType
        {
            Name = productType.Name
        };

        await context.ProductTypes.AddAsync(newProductType);
        await context.SaveChangesAsync();

        var productTypeSimpleResponse = new ProductTypeSimpleResponse
        {
            Id = newProductType.Id,
            Name = newProductType.Name
        };

        return productTypeSimpleResponse;
    }

    public async Task DeleteAsync(ProductType productType)
    {
        context.ProductTypes.Remove(productType);
        await context.SaveChangesAsync();
    }

    public async Task<List<ProductTypeSimpleResponse>> GetAllAsync()
    {
        return await context.ProductTypes
            .Select(productType => new ProductTypeSimpleResponse
            {
                Id = productType.Id,
                Name = productType.Name
            })
            .ToListAsync();
    }

    public async Task<ProductType?> GetByIdAsync(int id)
    {
        return await context.ProductTypes.FindAsync(id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
