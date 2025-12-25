using Azure.Storage.Blobs;
using ECommerce.Catalog.Application.Interfaces;
using ECommerce.Catalog.Application.Products.Queries;
using ECommerce.Catalog.Application.Services;
using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Events;
using ECommerce.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.DepencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CatalogDb"))
        );

        services.AddSingleton<BlobServiceClient>(sp =>
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorage");
            return new BlobServiceClient(connectionString);
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();

        services.AddScoped<IImageStorageService, AzureBlobImageStorageService>();
        services.AddSingleton<IEventPublisher, KafkaEventPublisher>();
        return services;
    }
}
