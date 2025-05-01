using ECommerce.Catalog.Domain.Events.shared;

namespace ECommerce.Catalog.Domain.Events.Product;
public class ProductAddedEvent : DomainEvent
{
    public Guid ProductId { get; }
    public string Name { get; }

    public ProductAddedEvent(Guid productId, string name)
    {
        ProductId = productId;
        Name = name;
    }
}
