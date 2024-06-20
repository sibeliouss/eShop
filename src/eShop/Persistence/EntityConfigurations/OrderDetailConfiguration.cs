using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails").HasKey(od => od.Id);

        builder.Property(od => od.Id).HasColumnName("Id").IsRequired();
        builder.Property(od => od.OrderId).HasColumnName("OrderId");
        builder.Property(od => od.ProductId).HasColumnName("ProductId");
        builder.Property(od => od.Quantity).HasColumnName("Quantity");
        builder.Property(od => od.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(od => od.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(od => od.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(od => !od.DeletedDate.HasValue);
        
        //composite key
        builder.HasKey(od =>new
        {
            od.ProductId,od.OrderId
        });
        
        builder.OwnsOne(od => od.Price, price =>
        {
            price.Property(m => m.Value).HasColumnType("money");
            price.Property(m => m.Currency).HasMaxLength(5);
        });
    }
}