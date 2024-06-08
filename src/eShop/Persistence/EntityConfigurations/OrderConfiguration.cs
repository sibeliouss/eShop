using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.OrderNumber).HasColumnName("OrderNumber");
        builder.Property(o => o.Quantity).HasColumnName("Quantity");
        builder.Property(o => o.Price).HasColumnName("Price");
        builder.Property(o => o.PaymentDate).HasColumnName("PaymentDate");
        builder.Property(o => o.PaymentNumber).HasColumnName("PaymentNumber");
        builder.Property(o => o.PaymentType).HasColumnName("PaymentType");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}