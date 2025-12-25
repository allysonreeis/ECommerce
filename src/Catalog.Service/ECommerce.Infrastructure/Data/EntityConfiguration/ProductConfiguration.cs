using ECommerce.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.EntityConfiguration;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(e => e.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(e => e.Sku)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Images)
            .IsRequired(false)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
            .Metadata.SetValueComparer(
                new ValueComparer<ICollection<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime");
        builder.Property(e => e.UpdatedAt)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(e => e.DeletedAt)
            .HasColumnType("datetime");

        builder.Navigation(e => e.Category)
            .AutoInclude(); // Automatically include the related category entity

        // relational configuration with category
        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Global filter for soft delete by status
        builder.HasQueryFilter(e => e.DeletedAt == null && e.LifeCycleStatus != ProductLifeCycleStatus.Deleted);
    }
}
