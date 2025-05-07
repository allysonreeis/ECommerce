namespace ECommerce.Catalog.Application.UseCases.AddProduct;
public class AddProductOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public Guid CategoryId { get; set; }

    public AddProductOutput(Guid id, string name, string description, decimal price, string sku, Guid categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Sku = sku;
        CategoryId = categoryId;
    }
}
