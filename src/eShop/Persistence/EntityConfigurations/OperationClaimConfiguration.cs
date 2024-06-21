using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Shoppings.Constants;
using Application.Features.Customers.Constants;

using Application.Features.Orders.Constants;
using Application.Features.OrderDetails.Constants;
using Application.Features.BillingAddresses.Constants;
using Application.Features.Addresses.Constants;
using Application.Features.ProductDiscounts.Constants;

using Application.Features.Products.Constants;




using Application.Features.OrderInformations.Constants;



namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion
  
    #region Categories
    featureOperationClaims.AddRange(
        [
            new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
            new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
            new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
            new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
            new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
            new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
        ]
    );
    #endregion
  
 
 #region OrderInformations
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = OrderInformationsOperationClaims.Admin },
         new() { Id = ++lastId, Name = OrderInformationsOperationClaims.Read },
         new() { Id = ++lastId, Name = OrderInformationsOperationClaims.Write },
         new() { Id = ++lastId, Name = OrderInformationsOperationClaims.Create },
         new() { Id = ++lastId, Name = OrderInformationsOperationClaims.Update },
         new() { Id = ++lastId, Name = OrderInformationsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Shoppings
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = ShoppingsOperationClaims.Admin },
         new() { Id = ++lastId, Name = ShoppingsOperationClaims.Read },
         new() { Id = ++lastId, Name = ShoppingsOperationClaims.Write },
         new() { Id = ++lastId, Name = ShoppingsOperationClaims.Create },
         new() { Id = ++lastId, Name = ShoppingsOperationClaims.Update },
         new() { Id = ++lastId, Name = ShoppingsOperationClaims.Delete },
     ]
 );
 #endregion
 

 #region Products
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = ProductsOperationClaims.Admin },
         new() { Id = ++lastId, Name = ProductsOperationClaims.Read },
         new() { Id = ++lastId, Name = ProductsOperationClaims.Write },
         new() { Id = ++lastId, Name = ProductsOperationClaims.Create },
         new() { Id = ++lastId, Name = ProductsOperationClaims.Update },
         new() { Id = ++lastId, Name = ProductsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Orders
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = OrdersOperationClaims.Admin },
         new() { Id = ++lastId, Name = OrdersOperationClaims.Read },
         new() { Id = ++lastId, Name = OrdersOperationClaims.Write },
         new() { Id = ++lastId, Name = OrdersOperationClaims.Create },
         new() { Id = ++lastId, Name = OrdersOperationClaims.Update },
         new() { Id = ++lastId, Name = OrdersOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region OrderDetails
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Admin },
         new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Read },
         new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Write },
         new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Create },
         new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Update },
         new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region BillingAddresses
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = BillingAddressesOperationClaims.Admin },
         new() { Id = ++lastId, Name = BillingAddressesOperationClaims.Read },
         new() { Id = ++lastId, Name = BillingAddressesOperationClaims.Write },
         new() { Id = ++lastId, Name = BillingAddressesOperationClaims.Create },
         new() { Id = ++lastId, Name = BillingAddressesOperationClaims.Update },
         new() { Id = ++lastId, Name = BillingAddressesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Addresses
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = AddressesOperationClaims.Admin },
         new() { Id = ++lastId, Name = AddressesOperationClaims.Read },
         new() { Id = ++lastId, Name = AddressesOperationClaims.Write },
         new() { Id = ++lastId, Name = AddressesOperationClaims.Create },
         new() { Id = ++lastId, Name = AddressesOperationClaims.Update },
         new() { Id = ++lastId, Name = AddressesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region ProductDiscounts
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = ProductDiscountsOperationClaims.Admin },
         new() { Id = ++lastId, Name = ProductDiscountsOperationClaims.Read },
         new() { Id = ++lastId, Name = ProductDiscountsOperationClaims.Write },
         new() { Id = ++lastId, Name = ProductDiscountsOperationClaims.Create },
         new() { Id = ++lastId, Name = ProductDiscountsOperationClaims.Update },
         new() { Id = ++lastId, Name = ProductDiscountsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Customers
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = CustomersOperationClaims.Admin },
         new() { Id = ++lastId, Name = CustomersOperationClaims.Read },
         new() { Id = ++lastId, Name = CustomersOperationClaims.Write },
         new() { Id = ++lastId, Name = CustomersOperationClaims.Create },
         new() { Id = ++lastId, Name = CustomersOperationClaims.Update },
         new() { Id = ++lastId, Name = CustomersOperationClaims.Delete },
     ]
 );
 #endregion
 
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
