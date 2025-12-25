using ECommerce.Catalog.Application.Common;
using ECommerce.Catalog.Application.Products.Queries;
using ECommerce.Catalog.Application.Products.Queries.GetPagedProducts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data;

internal class ProductReadRepository : IProductReadRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductReadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public async Task<PagedResult<ProductListItem>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = (from product in _appDbContext.Products
                    orderby product.Id
                    select new ProductListItem
                    {
                        Id = product.Id,
                        Name = product.Name
                    })
                    .AsNoTracking()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);

        var total = await _appDbContext.Products.CountAsync(cancellationToken);
        var products = await query.ToListAsync(cancellationToken);

        return new PagedResult<ProductListItem>
        {
            Items = products,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = total
        };
    }
}
