using ECommerce.Catalog.Application.Common;
using MediatR;

namespace ECommerce.Catalog.Application.Products.Queries.GetPagedProducts;

public sealed class GetPagedProductsHandler : IRequestHandler<GetPagedProductsQuery, PagedResult<ProductListItem>>
{
    private readonly IProductReadRepository _productRepository;
    
    public GetPagedProductsHandler(IProductReadRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedResult<ProductListItem>> Handle(GetPagedProductsQuery query, CancellationToken cancellationToken)
    {
        var pagedProducts = await _productRepository.GetPagedAsync(query.PageNumber, query.PageSize, cancellationToken);
        
        return pagedProducts;
    }
}
