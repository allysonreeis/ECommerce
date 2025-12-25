using ECommerce.Catalog.Domain.Events.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Events.Product;
public class ProductDeletedEventHandler : IDomainEventHandler<ProductRejectedEvent>
{
    public Task Handle(ProductRejectedEvent domainEvent)
    {
        Console.WriteLine($"Handle::Processing Envent [{nameof(ProductRejectedEvent)}]");
        // Handle the event (e.g., send a notification, update a database, etc.)
        return Task.CompletedTask;
    }
}
