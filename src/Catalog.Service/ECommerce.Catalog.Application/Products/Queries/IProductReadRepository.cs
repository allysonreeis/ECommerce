using ECommerce.Catalog.Application.Common;
using ECommerce.Catalog.Application.Products.Queries.GetPagedProducts;

namespace ECommerce.Catalog.Application.Products.Queries;

public interface IProductReadRepository
{
    public Task<PagedResult<ProductListItem>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
}
