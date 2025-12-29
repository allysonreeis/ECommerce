using ECommerce.Catalog.Application.Services;
using ECommerce.Catalog.Domain.DataAccess.Interfaces;
using MediatR;

namespace ECommerce.Catalog.Application.UseCases.AddProductImage;
public class AddProductImage : IRequestHandler<AddProductImageInput, string>
{
    private readonly IImageStorageService _imageStorageService;
    private readonly IProductRepository _productRepository;

    public AddProductImage(IImageStorageService imageStorageService, IProductRepository productRepository)
    {
        _imageStorageService = imageStorageService;
        _productRepository = productRepository;
    }
    public async Task<string> Handle(AddProductImageInput request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
            }


            var imageUrl = await _imageStorageService.UploadImageAsync(request.Image, request.ContentType, cancellationToken);
            product.Images.Add(imageUrl);

            await _productRepository.UpdateAsync(product, cancellationToken);

            return imageUrl;
        }
        catch (Exception ex)
        {
            // Log the exception (logging mechanism not shown here)
            throw new ApplicationException("An error occurred while adding the product image.", ex);
        }
    }
}
