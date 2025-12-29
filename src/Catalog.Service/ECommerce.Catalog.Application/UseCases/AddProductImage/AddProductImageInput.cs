using MediatR;

namespace ECommerce.Catalog.Application.UseCases.AddProductImage;
public class AddProductImageInput : IRequest<string>
{
    public Guid ProductId { get; set; }
    public Stream Image { get; set; }
    //public string FileName { get; set; }
    public string ContentType { get; set; }

    public AddProductImageInput(Stream image, string contentType, Guid productId)
    {
        Image = image;
        ContentType = contentType;
        ProductId = productId;
    }
}
