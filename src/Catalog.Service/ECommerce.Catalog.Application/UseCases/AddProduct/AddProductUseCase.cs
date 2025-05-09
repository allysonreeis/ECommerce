using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using ECommerce.Catalog.Domain.Entities;
using MediatR;

namespace ECommerce.Catalog.Application.UseCases.AddProduct;
public class AddProductUseCase : IRequestHandler<AddProductInput, AddProductOutput>
{
    private readonly IProductRepository _productRepository;

    public AddProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<AddProductOutput> Handle(AddProductInput input, CancellationToken cancellationToken)
    {

        var product = new Product(input.Name, input.Description, input.Price, input.Sku, input.CategoryId, ["linkimage.com/image_1", "linkimage.com/image_2", "linkimage.com/image_3"]);

        var productAdded = await _productRepository.AddAsync(product);

        var output = new AddProductOutput(productAdded.Id, productAdded.Name, productAdded.Description, productAdded.Price, productAdded.Sku, productAdded.CategoryId);

        return output;
    }
}
