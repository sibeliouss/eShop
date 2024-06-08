using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderInformations;

public interface IOrderInformationService
{
    Task<OrderInformation?> GetAsync(
        Expression<Func<OrderInformation, bool>> predicate,
        Func<IQueryable<OrderInformation>, IIncludableQueryable<OrderInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OrderInformation>?> GetListAsync(
        Expression<Func<OrderInformation, bool>>? predicate = null,
        Func<IQueryable<OrderInformation>, IOrderedQueryable<OrderInformation>>? orderBy = null,
        Func<IQueryable<OrderInformation>, IIncludableQueryable<OrderInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OrderInformation> AddAsync(OrderInformation orderInformation);
    Task<OrderInformation> UpdateAsync(OrderInformation orderInformation);
    Task<OrderInformation> DeleteAsync(OrderInformation orderInformation, bool permanent = false);
}
