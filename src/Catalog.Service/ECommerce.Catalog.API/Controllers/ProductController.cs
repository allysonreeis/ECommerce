using ECommerce.Catalog.Application.UseCases.AddProduct;
using ECommerce.Catalog.Application.UseCases.DeleteProduct;
using ECommerce.Catalog.Application.UseCases.GetProductById;
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
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request, CancellationToken cancellationToken)
    {
        if (request == null) return BadRequest();
        var input = request.ToInput();

        await _mediator.Send(input, cancellationToken);

        return Ok(request);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty) return BadRequest();

        var input = new GetProductByIdInput(id);
        var product = await _mediator.Send(input, cancellationToken);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty) return BadRequest();
        var input = new DeleteProductInput(id);
        var isDeleted = await _mediator.Send(input, cancellationToken);

        if (!isDeleted) return NotFound();

        return NoContent();
    }
}
