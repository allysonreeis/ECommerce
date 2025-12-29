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

    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(product);

        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty) throw new ArgumentException("Invalid product ID", nameof(id));

        var product = await _dbContext.Products.FindAsync(id);
        return product ?? throw new KeyNotFoundException($"Product with ID {id} not found.");
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync();
    }
}
