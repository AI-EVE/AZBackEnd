using System;
using API.IRepositories;
using API.IServices;
using API.Repositories;
using API.Services;

namespace API.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICarMakerRepository, CarMakerRepository>();
        services.AddScoped<ICarModelRepository, CarModelRepository>();
        services.AddScoped<ICarGenerationRepository, CarGenerationRepository>();
        services.AddScoped<ICarSectionRepository, CarSectionRepository>();
        services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        services.AddScoped<IProductMakerRepository, ProductMakerRepository>();
        services.AddScoped<IBlobService, BlobService>();
        services.AddScoped<IUploadImageService, UploadImageService>();
        services.AddScoped<IDeleteImageService, DeleteImageService>();
    }
}
