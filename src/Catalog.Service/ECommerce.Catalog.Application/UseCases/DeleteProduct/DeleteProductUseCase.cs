using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using ECommerce.Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.DeleteProduct;
public class DeleteProductUseCase : IRequestHandler<DeleteProductInput, bool>
{
    private readonly IProductRepository _productRepository;
    public DeleteProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<bool> Handle(DeleteProductInput request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null) throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
        if (product.LifeCycleStatus == ProductLifeCycleStatus.Deleted) throw new InvalidOperationException("Product is already deleted.");

        product.MarkAsDeleted();

        var isDeleted = await _productRepository.DeleteAsync(product);

        return isDeleted;
    }
}
