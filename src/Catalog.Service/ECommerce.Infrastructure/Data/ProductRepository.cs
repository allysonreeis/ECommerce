using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using ECommerce.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> DeleteAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
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
