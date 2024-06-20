using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BillingAddressConfiguration : IEntityTypeConfiguration<BillingAddress>
{
    public void Configure(EntityTypeBuilder<BillingAddress> builder)
    {
        builder.ToTable("BillingAddresses").HasKey(ba => ba.Id);

        builder.Property(ba => ba.Id).HasColumnName("Id").IsRequired();
        builder.Property(ba => ba.CustomerId).HasColumnName("CustomerId");
        builder.Property(ba => ba.Country).HasColumnName("Country");
        builder.Property(ba => ba.City).HasColumnName("City");
        builder.Property(ba => ba.ZipCode).HasColumnName("ZipCode");
        builder.Property(ba => ba.ContactName).HasColumnName("ContactName");
        builder.Property(ba => ba.Description).HasColumnName("Description");
        builder.Property(ba => ba.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ba => ba.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ba => ba.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ba => !ba.DeletedDate.HasValue);
    }
}