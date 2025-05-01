using ECommerce.Catalog.Application.UseCases.AddProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] ProductRequest request, CancellationToken cancellationToken)
    {
        if (request == null) return BadRequest();
        var input = request.ToInput();

        await _mediator.Send(input, cancellationToken);

        return Ok(request);
    }
}
