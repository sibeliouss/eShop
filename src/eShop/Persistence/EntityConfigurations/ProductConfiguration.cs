using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.Brand).HasColumnName("Brand");
        builder.Property(p => p.ImgUrl).HasColumnName("ImgUrl");
        builder.Property(p => p.Description).HasColumnName("Description");
        builder.Property(p => p.Barcode).HasColumnName("Barcode");
        builder.Property(p => p.Stock).HasColumnName("Stock");
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
     
        builder.Property(p => p.OrderId).HasColumnName("OrderId");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        
        builder.OwnsOne(p => p.Price, price =>
        {
            price.Property(m => m.Value).HasColumnType("money");
            price.Property(m => m.Currency).HasMaxLength(5);
        });
    }
}