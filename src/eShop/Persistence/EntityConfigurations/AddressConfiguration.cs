using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CustomerId).HasColumnName("CustomerId");
        builder.Property(a => a.Country).HasColumnName("Country");
        builder.Property(a => a.City).HasColumnName("City");
        builder.Property(a => a.ZipCode).HasColumnName("ZipCode");
        builder.Property(a => a.ContactName).HasColumnName("ContactName");
        builder.Property(a => a.Description).HasColumnName("Description");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}