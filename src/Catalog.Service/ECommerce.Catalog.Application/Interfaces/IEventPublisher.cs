using ECommerce.Catalog.Domain.Events.shared;

namespace ECommerce.Catalog.Application.Interfaces;
public interface IEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent, string topic, CancellationToken cancellationToken);
}
