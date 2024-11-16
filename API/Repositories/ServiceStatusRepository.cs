using API.Data;
using API.DTOs.ServiceStatusDTOs;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class ServiceStatusRepository(ApplicationDbContext context) : IServiceStatusRepository
{
    public async Task<ServiceStatusSimpleResponse> AddServiceStatusAsync(AddServiceStatusSimpleRequest request)
    {
        var serviceStatus = new ServiceStatus
        {
            Status = request.Status,
            Description = request.Description
        };

        await context.ServiceStatuses.AddAsync(serviceStatus);
        await context.SaveChangesAsync();

        return new ServiceStatusSimpleResponse
        {
            Id = serviceStatus.Id,
            Status = serviceStatus.Status,
            Description = serviceStatus.Description
        };
    }

    public async Task DeleteServiceStatusAsync(ServiceStatus serviceStatus)
    {
        context.ServiceStatuses.Remove(serviceStatus);
        await context.SaveChangesAsync();
    }

    public async Task<ServiceStatus?> GetServiceStatusAsync(int id)
    {
        return await context.ServiceStatuses.FindAsync(id);
    }

    public async Task<List<ServiceStatusSimpleResponse>> GetServiceStatusesAsync()
    {
        return await context.ServiceStatuses
            .Select(serviceStatus => new ServiceStatusSimpleResponse
            {
                Id = serviceStatus.Id,
                Status = serviceStatus.Status,
                Description = serviceStatus.Description
            })
            .ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
