using ECommerce.Catalog.Domain.Events.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Events.Product;
public class ProductDeletedEventHandler : IDomainEventHandler<ProductDeletedEvent>
{
    public Task Handle(ProductDeletedEvent domainEvent)
    {
        Console.WriteLine($"Handle::Processing Envent [{nameof(ProductDeletedEvent)}]");
        // Handle the event (e.g., send a notification, update a database, etc.)
        return Task.CompletedTask;
    }
}
