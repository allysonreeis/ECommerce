namespace ECommerce.Catalog.Application.Common;

public sealed class PagedResult<T>
{
    public List<T> Items { get; init; } = [];
    public int PageSize { get; init; }
    public int PageNumber { get; init; }
    public int TotalItems { get; init; }

    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
}
