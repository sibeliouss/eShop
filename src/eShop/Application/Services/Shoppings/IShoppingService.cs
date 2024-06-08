using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shoppings;

public interface IShoppingService
{
    Task<Shopping?> GetAsync(
        Expression<Func<Shopping, bool>> predicate,
        Func<IQueryable<Shopping>, IIncludableQueryable<Shopping, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Shopping>?> GetListAsync(
        Expression<Func<Shopping, bool>>? predicate = null,
        Func<IQueryable<Shopping>, IOrderedQueryable<Shopping>>? orderBy = null,
        Func<IQueryable<Shopping>, IIncludableQueryable<Shopping, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Shopping> AddAsync(Shopping shopping);
    Task<Shopping> UpdateAsync(Shopping shopping);
    Task<Shopping> DeleteAsync(Shopping shopping, bool permanent = false);
}
