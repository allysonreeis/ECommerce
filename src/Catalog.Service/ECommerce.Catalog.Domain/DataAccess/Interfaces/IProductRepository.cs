using ECommerce.Catalog.Domain.Entities;

namespace ECommerce.Catalog.Domain.DataAccess.Interfaces;
public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task<bool> DeleteAsync(Product product);
}
