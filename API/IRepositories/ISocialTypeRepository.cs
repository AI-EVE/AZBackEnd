using System;
using API.DTOs.SocialTypeDTOs;
using API.Models;

namespace API.IRepositories;

public interface ISocialTypeRepository
{
    Task<List<SocialTypeSimpleResponse>> GetAllAsync();
    Task<SocialType?> GetByIdAsync(int id);
    Task<SocialTypeSimpleResponse> AddAsync(SocialType socialType);
    Task<bool> NameExistsAsync(string name);
    Task<bool> SaveChangesAsync();
    Task DeleteAsync(SocialType socialType);
}
