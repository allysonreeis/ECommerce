using Confluent.Kafka;
using ECommerce.Catalog.Application.Interfaces;
using ECommerce.Catalog.Domain.Events.shared;
using System.Text.Json;

namespace ECommerce.Infrastructure.Events;

internal class KafkaEventPublisher : IEventPublisher
{
    private readonly IProducer<Null, string> _producer;

    public KafkaEventPublisher()
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
            Acks = Acks.All
        };

        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task PublishAsync(IDomainEvent domainEvent, string topic, CancellationToken cancellationToken)
    {
        var message = new Message<Null, string>
        {
            Value = JsonSerializer.Serialize(domainEvent, domainEvent.GetType())
        };

        var result = await _producer.ProduceAsync(topic, message, cancellationToken);
        Console.WriteLine($"Message sent to topic {result.Topic}, partition {result.Partition}, offset {result.Offset}");
    }
}
