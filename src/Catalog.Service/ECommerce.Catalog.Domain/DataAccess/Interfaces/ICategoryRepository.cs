using ECommerce.Catalog.Domain.Entities;

namespace ECommerce.Catalog.Domain.DataAccess.Interfaces;
public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid id);
}
