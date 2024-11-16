using System;
using API.DTOs.ServiceStatusDTOs;
using API.Models;

namespace API.IRepositories;

public interface IServiceStatusRepository
{
    Task<ServiceStatusSimpleResponse> AddServiceStatusAsync(AddServiceStatusSimpleRequest request);
    Task<ServiceStatus?> GetServiceStatusAsync(int id);
    Task<List<ServiceStatusSimpleResponse>> GetServiceStatusesAsync();
    Task<bool> SaveChangesAsync();
    Task DeleteServiceStatusAsync(ServiceStatus serviceStatus);
}
