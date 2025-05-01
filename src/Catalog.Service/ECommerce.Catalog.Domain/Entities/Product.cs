using ECommerce.Catalog.Domain.Entities.shared;
using ECommerce.Catalog.Domain.Events.Product;

namespace ECommerce.Catalog.Domain.Entities;
public class Product : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public Guid CategoryId { get; private set; }
    public decimal Price { get; private set; }
    public string Sku { get; private set; }
    public int StockQuantity { get; set; }
    public ICollection<string> Images { get; private set; } = new List<string>();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public Product(string name, string description, decimal price, string sku, int stockQuantity, Guid categoryId, ICollection<string> images)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Sku = sku;
        StockQuantity = stockQuantity;
        CategoryId = categoryId;
        Images = images;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;

        AddDomainEvent(new ProductAddedEvent(Id, Name));
    }
}
