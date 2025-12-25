using ECommerce.Catalog.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Catalog.Application.Products.Queries.GetPagedProducts;

public sealed class GetPagedProductsQuery : IRequest<PagedResult<ProductListItem>>
{
    public int PageNumber { get; }
    public int PageSize { get; }

    public GetPagedProductsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
