using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.DeleteProduct;
public class DeleteProductInput : IRequest<bool>
{
    public Guid Id { get; set; }
    public DeleteProductInput(Guid id)
    {
        Id = id;
    }
}
