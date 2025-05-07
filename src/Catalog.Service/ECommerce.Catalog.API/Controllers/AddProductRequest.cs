using ECommerce.Catalog.Application.UseCases.AddProduct;
using ECommerce.Catalog.Domain.Entities;

namespace ECommerce.Catalog.API.Controllers;

public class AddProductRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public int StockQuantity { get; set; }
    public IFormFileCollection Files { get; set; }

    public AddProductInput ToInput()
    {
        return new AddProductInput(Name, Description, CategoryId, Price, Sku, StockQuantity);
    }
}
