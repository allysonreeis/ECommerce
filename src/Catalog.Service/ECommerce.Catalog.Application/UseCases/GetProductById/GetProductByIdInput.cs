using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.GetProductById;
public class GetProductByIdInput : IRequest<GetProductByIdOutput>
{
    public Guid ProductId { get; set; }
    public GetProductByIdInput(Guid productId)
    {
        ProductId = productId;
    }
}
