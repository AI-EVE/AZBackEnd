using API.Data;
using API.DTOs.SocialTypeDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class SocialTypeRepository(ApplicationDbContext context) : ISocialTypeRepository
{


    public async Task<SocialTypeSimpleResponse> AddAsync(SocialType socialType)
    {
        await context.SocialTypes.AddAsync(socialType);
        await context.SaveChangesAsync();

        return new SocialTypeSimpleResponse
        {
            Id = socialType.Id,
            Type = socialType.Type,
            LogoUrl = socialType.LogoUrl
        };
    }

    public async Task DeleteAsync(SocialType socialType)
    {
        context.SocialTypes.Remove(socialType);
        await context.SaveChangesAsync();
    }

    public async Task<List<SocialTypeSimpleResponse>> GetAllAsync()
    {
        return await context.SocialTypes.Select(socialType => new SocialTypeSimpleResponse
        {
            Id = socialType.Id,
            Type = socialType.Type,
            LogoUrl = socialType.LogoUrl
        }).ToListAsync();
    }

    public async Task<SocialType?> GetByIdAsync(int id)
    {
        return await context.SocialTypes.FindAsync(id);
    }

    public async Task<bool> NameExistsAsync(string name)
    {
        return await context.SocialTypes.AnyAsync(socialType => socialType.Type == name);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
