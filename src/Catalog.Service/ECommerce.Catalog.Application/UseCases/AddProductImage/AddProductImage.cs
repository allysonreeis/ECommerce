using ECommerce.Catalog.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.AddProductImage;
public class AddProductImage : IRequestHandler<AddProductImageInput, string>
{
    private readonly IImageStorageService _imageStorageService;

    public AddProductImage(IImageStorageService imageStorageService)
    {
        _imageStorageService = imageStorageService;
    }
    public async Task<string> Handle(AddProductImageInput request, CancellationToken cancellationToken)
    {
        return await _imageStorageService.UploadImageAsync(request.Image, request.ContentType, cancellationToken);
    }
}
