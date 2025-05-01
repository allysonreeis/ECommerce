using ECommerce.Catalog.Domain.Events.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Events.Product;
public class ProductDeletedEvent : DomainEvent
{
    public Guid ProductId { get; }
    public string Name { get; }
    public ProductDeletedEvent(Guid productId, string name)
    {
        ProductId = productId;
        Name = name;
    }
}
