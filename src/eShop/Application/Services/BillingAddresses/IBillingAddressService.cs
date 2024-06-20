using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BillingAddresses;

public interface IBillingAddressService
{
    Task<BillingAddress?> GetAsync(
        Expression<Func<BillingAddress, bool>> predicate,
        Func<IQueryable<BillingAddress>, IIncludableQueryable<BillingAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BillingAddress>?> GetListAsync(
        Expression<Func<BillingAddress, bool>>? predicate = null,
        Func<IQueryable<BillingAddress>, IOrderedQueryable<BillingAddress>>? orderBy = null,
        Func<IQueryable<BillingAddress>, IIncludableQueryable<BillingAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BillingAddress> AddAsync(BillingAddress billingAddress);
    Task<BillingAddress> UpdateAsync(BillingAddress billingAddress);
    Task<BillingAddress> DeleteAsync(BillingAddress billingAddress, bool permanent = false);
}
