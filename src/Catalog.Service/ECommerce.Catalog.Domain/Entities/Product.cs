namespace ECommerce.Catalog.Domain.Entities;
public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public Guid CategoryId { get; private set; }
    public decimal Price { get; private set; }


}
