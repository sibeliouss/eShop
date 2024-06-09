using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShoppingConfiguration : IEntityTypeConfiguration<Shopping>
{
    public void Configure(EntityTypeBuilder<Shopping> builder)
    {
        builder.ToTable("Shoppings").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CustomerId).HasColumnName("CustomerId");
        builder.Property(s => s.ProductId).HasColumnName("ProductId");
        builder.Property(s => s.Quantity).HasColumnName("Quantity");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        
        builder.OwnsOne(s => s.Price, price =>
        {
            price.Property(m => m.Value).HasColumnType("money");
            price.Property(m => m.Currency).HasMaxLength(5);
        });
    }
}