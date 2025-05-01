using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.GetProductById;
public class GetProductByIdUseCase : IRequestHandler<GetProductByIdInput, GetProductByIdOutput>
{
    private readonly IProductRepository _productRepository;
    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<GetProductByIdOutput> Handle(GetProductByIdInput request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product == null) throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");

        var output = product;

        return output;
    }
}
