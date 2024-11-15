using System;
using API.Data;
using API.DTOs.ProductMakerDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class ProductMakerRepository(ApplicationDbContext context) : IProductMakerRepository
{
    public async Task<ProductMakerSimpleResponse> AddAsync(ProductMaker productMaker)
    {
        await context.ProductMakers.AddAsync(productMaker);

        await context.SaveChangesAsync();

        return new ProductMakerSimpleResponse
        {
            Id = productMaker.Id,
            Name = productMaker.Name,
            LogoUrl = productMaker.LogoUrl
        };
    }

    public async Task DeleteAsync(ProductMaker productMaker)
    {
        context.ProductMakers.Remove(productMaker);

        await context.SaveChangesAsync();
    }

    public async Task<List<ProductMakerSimpleResponse>> GetAllAsync()
    {
        var productMakers = await context.ProductMakers.Select(productMaker => new ProductMakerSimpleResponse
        {
            Id = productMaker.Id,
            Name = productMaker.Name,
            LogoUrl = productMaker.LogoUrl
        }).ToListAsync();

        return productMakers;
    }

    public async Task<ProductMaker?> GetByIdAsync(int id)
    {
        var productMaker = await context.ProductMakers.FindAsync(id);

        return productMaker;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
