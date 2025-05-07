using ECommerce.Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.UseCases.GetProductById;
public class GetProductByIdOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public ICollection<string> ImageUrl { get; set; }

    public GetProductByIdOutput(Guid id, string name, string description, decimal price, Category category, ICollection<string> imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        ImageUrl = imageUrl;
    }

    public static implicit operator GetProductByIdOutput(Product product)
    {
        return new GetProductByIdOutput(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Category,
            product.Images
        );
    }
}
