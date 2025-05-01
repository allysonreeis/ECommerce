using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using ECommerce.Catalog.Domain.Entities;

namespace ECommerce.Infrastructure.Data;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentException("Invalid product ID", nameof(id));

        var product = await _dbContext.Products.FindAsync(id);
        return product ?? throw new KeyNotFoundException($"Product with ID {id} not found.");
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
