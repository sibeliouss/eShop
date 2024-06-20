using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
{
    public void Configure(EntityTypeBuilder<ProductDiscount> builder)
    {
        builder.ToTable("ProductDiscounts").HasKey(pd => pd.Id);

        builder.Property(pd => pd.Id).HasColumnName("Id").IsRequired();
        builder.Property(pd => pd.ProductId).HasColumnName("ProductId");
        builder.Property(pd => pd.DiscountPercentage).HasColumnName("DiscountPercentage");
        builder.Property(pd => pd.StartDate).HasColumnName("StartDate");
        builder.Property(pd => pd.EndDate).HasColumnName("EndDate");
        builder.Property(pd => pd.DiscountPrice).HasColumnName("DiscountPrice");
        builder.Property(pd => pd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pd => pd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pd => pd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pd => !pd.DeletedDate.HasValue);
    }
}