using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.AddProductImage;
public class AddProductImageInput : IRequest<string>
{
    //public string ProductId { get; set; }
    public Stream Image { get; set; }
    //public string FileName { get; set; }
    public string ContentType { get; set; }

    public AddProductImageInput(Stream image, string contentType)
    {
        Image = image;
        ContentType = contentType;
    }
}
