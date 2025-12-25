using ECommerce.Catalog.Application.Interfaces;
using ECommerce.Catalog.Domain.Events.shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Events;
internal class DomainEventService : IDomainEventService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IEventPublisher _eventPublisher;

    public DomainEventService(IServiceProvider serviceProvider, IEventPublisher eventPublisher)
    {
        _serviceProvider = serviceProvider;
        _eventPublisher = eventPublisher;
    }

    public async Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
    {
        using var scope = _serviceProvider.CreateScope();
        var handlers = scope.ServiceProvider.GetServices<IDomainEventHandler<TEvent>>();

        foreach (var handler in handlers)
        {
            await handler.Handle(domainEvent);
        }

        await _eventPublisher.PublishAsync(domainEvent, "product.events", CancellationToken.None);
    }
}
