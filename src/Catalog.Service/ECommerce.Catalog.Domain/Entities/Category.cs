namespace ECommerce.Catalog.Domain.Entities;
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; private set; }
}
