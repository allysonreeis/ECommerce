using ECommerce.Catalog.Domain.Entities;

namespace ECommerce.Catalog.Domain.DataAccess.Interfaces;
public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Product> AddAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken);
}
