﻿using ECommerce.Catalog.Application.UseCases.AddProduct;
using ECommerce.Catalog.Application.UseCases.AddProductImage;
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
    public async Task<IActionResult> AddProduct([FromForm] AddProductRequest request, CancellationToken cancellationToken)
    {
        if (request == null) return BadRequest();

        var input = request.ToInput();

        var output = await _mediator.Send(input, cancellationToken);

        return CreatedAtAction(nameof(GetProductById), new { id = output.Id }, output);
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

    [HttpPost("image")]
    public async Task<IActionResult> AddProductImage(IFormFile file, CancellationToken cancellationToken)
    {
        if (file == null || file.Length == 0) return BadRequest();
        var input = new AddProductImageInput(file.OpenReadStream(), file.ContentType);
        var imageUrl = await _mediator.Send(input, cancellationToken);
        return Ok(new { ImageUrl = imageUrl });
    }
}
