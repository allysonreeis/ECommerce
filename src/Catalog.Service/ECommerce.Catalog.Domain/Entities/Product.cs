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
    public ProductApprovalStatus ApprovalStatus { get; private set; } = ProductApprovalStatus.Draft;
    public ProductLifeCycleStatus LifeCycleStatus { get; private set; } = ProductLifeCycleStatus.Inactive;
    
    private List<string> _images = [];
    public IReadOnlyCollection<string> Images => _images.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public DateTime? DeletedAt { get; private set; } = null;

    public Product(string name, string description, decimal price, string sku, Guid categoryId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Sku = sku;
        CategoryId = categoryId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;

        //AddDomainEvent(new ProductAddedEvent(Id, Name));
    }

    public void AddImage(string imageUrl)
    {
        _images ??= [];
        _images.Add(imageUrl);
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkAsRejected()
    {
        if (ApprovalStatus == ProductApprovalStatus.Rejected)
            throw new InvalidOperationException("Product is already rejected.");

        ApprovalStatus = ProductApprovalStatus.Rejected;
        DeletedAt = DateTime.UtcNow;

        //AddDomainEvent(new ProductRejectedEvent(Id, Name));
    }

    public void MarkAsDraft()
    {
        if (ApprovalStatus == ProductApprovalStatus.Draft)
            throw new InvalidOperationException("Product is already in draft status.");
        ApprovalStatus = ProductApprovalStatus.Draft;
        //AddDomainEvent(new ProductStatusChangedEvent(Id, Name, Status));
    }

    public void MarkAsApproved()
    {
        if (ApprovalStatus == ProductApprovalStatus.Approved)
            throw new InvalidOperationException("Product is already in aprroved status.");
        ApprovalStatus = ProductApprovalStatus.Approved;
        //AddDomainEvent(new ProductStatusChangedEvent(Id, Name, Status));
    }

    public void MarkAsPending()
    {
        if (ApprovalStatus == ProductApprovalStatus.Pending)
            throw new InvalidOperationException("Product is already in pending status.");
        ApprovalStatus = ProductApprovalStatus.Pending;
        //AddDomainEvent(new ProductStatusChangedEvent(Id, Name, Status));
    }

    public void MarkAsDeleted()
    {
        if (LifeCycleStatus == ProductLifeCycleStatus.Deleted)
            throw new InvalidOperationException("Product is already deleted.");
        LifeCycleStatus = ProductLifeCycleStatus.Deleted;
        DeletedAt = DateTime.UtcNow;
        //AddDomainEvent(new ProductDeletedEvent(Id, Name));
    }
}
