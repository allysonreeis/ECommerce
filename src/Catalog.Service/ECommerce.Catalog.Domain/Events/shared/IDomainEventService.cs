namespace ECommerce.Catalog.Domain.Events.shared;
public interface IDomainEventService
{
    Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent;
}
