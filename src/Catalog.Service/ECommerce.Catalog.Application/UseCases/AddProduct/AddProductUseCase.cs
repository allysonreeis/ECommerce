using ECommerce.Catalog.Application.Interfaces;
using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using ECommerce.Catalog.Domain.Entities;
using ECommerce.Catalog.Domain.Events.Product;
using MediatR;

namespace ECommerce.Catalog.Application.UseCases.AddProduct;
public class AddProductUseCase : IRequestHandler<AddProductInput, AddProductOutput>
{
    private readonly IProductRepository _productRepository;
    private readonly IEventPublisher _eventPublisher;

    public AddProductUseCase(IProductRepository productRepository, IEventPublisher eventPublisher)
    {
        _productRepository = productRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<AddProductOutput> Handle(AddProductInput input, CancellationToken cancellationToken)
    {

        //var product = new Product(input.Name, input.Description, input.Price, input.Sku, input.CategoryId, ["linkimage.com/image_1", "linkimage.com/image_2", "linkimage.com/image_3"]);
        var product = new Product(input.Name, input.Description, input.Price, input.Sku, input.CategoryId, null);

        var productAdded = await _productRepository.AddAsync(product, cancellationToken);

        var productAddedEvent = new ProductAddedEvent(productAdded.Id, productAdded.Name);
        await _eventPublisher.PublishAsync(productAddedEvent, "product.events", cancellationToken);

        var output = new AddProductOutput(productAdded.Id, productAdded.Name, productAdded.Description, productAdded.Price, productAdded.Sku, productAdded.CategoryId);

        return output;
    }
}
