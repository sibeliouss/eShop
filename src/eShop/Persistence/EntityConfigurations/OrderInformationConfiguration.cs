using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderInformationConfiguration : IEntityTypeConfiguration<OrderInformation>
{
    public void Configure(EntityTypeBuilder<OrderInformation> builder)
    {
        builder.ToTable("OrderInformations").HasKey(oi => oi.Id);

        builder.Property(oi => oi.Id).HasColumnName("Id").IsRequired();
        builder.Property(oi => oi.OrderNumber).HasColumnName("OrderNumber");
        builder.Property(oi => oi.OrderStatusEnum).HasColumnName("OrderStatusEnum");
        builder.Property(oi => oi.StatusDate).HasColumnName("StatusDate");
        builder.Property(oi => oi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oi => oi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oi => oi.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oi => !oi.DeletedDate.HasValue);
    }
}