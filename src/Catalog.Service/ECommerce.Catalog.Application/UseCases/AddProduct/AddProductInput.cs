using MediatR;

namespace ECommerce.Catalog.Application.UseCases.AddProduct;
public class AddProductInput : IRequest<AddProductOutput>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public int StockQuantity { get; set; }
    public ICollection<string> Images { get; set; } = new List<string>();
    public AddProductInput(string name, string description, Guid categoryId, decimal price, string sku, int stockQuantity, ICollection<string> images)
    {
        Name = name;
        Description = description;
        CategoryId = categoryId;
        Price = price;
        Sku = sku;
        StockQuantity = stockQuantity;
        Images = images;
    }
}
