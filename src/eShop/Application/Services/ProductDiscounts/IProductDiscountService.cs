using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductDiscounts;

public interface IProductDiscountService
{
    Task<ProductDiscount?> GetAsync(
        Expression<Func<ProductDiscount, bool>> predicate,
        Func<IQueryable<ProductDiscount>, IIncludableQueryable<ProductDiscount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductDiscount>?> GetListAsync(
        Expression<Func<ProductDiscount, bool>>? predicate = null,
        Func<IQueryable<ProductDiscount>, IOrderedQueryable<ProductDiscount>>? orderBy = null,
        Func<IQueryable<ProductDiscount>, IIncludableQueryable<ProductDiscount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductDiscount> AddAsync(ProductDiscount productDiscount);
    Task<ProductDiscount> UpdateAsync(ProductDiscount productDiscount);
    Task<ProductDiscount> DeleteAsync(ProductDiscount productDiscount, bool permanent = false);
}
