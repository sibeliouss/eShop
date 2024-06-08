using Application.Features.OrderInformations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderInformations;

public class OrderInformationManager : IOrderInformationService
{
    private readonly IOrderInformationRepository _orderInformationRepository;
    private readonly OrderInformationBusinessRules _orderInformationBusinessRules;

    public OrderInformationManager(IOrderInformationRepository orderInformationRepository, OrderInformationBusinessRules orderInformationBusinessRules)
    {
        _orderInformationRepository = orderInformationRepository;
        _orderInformationBusinessRules = orderInformationBusinessRules;
    }

    public async Task<OrderInformation?> GetAsync(
        Expression<Func<OrderInformation, bool>> predicate,
        Func<IQueryable<OrderInformation>, IIncludableQueryable<OrderInformation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OrderInformation? orderInformation = await _orderInformationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return orderInformation;
    }

    public async Task<IPaginate<OrderInformation>?> GetListAsync(
        Expression<Func<OrderInformation, bool>>? predicate = null,
        Func<IQueryable<OrderInformation>, IOrderedQueryable<OrderInformation>>? orderBy = null,
        Func<IQueryable<OrderInformation>, IIncludableQueryable<OrderInformation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OrderInformation> orderInformationList = await _orderInformationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return orderInformationList;
    }

    public async Task<OrderInformation> AddAsync(OrderInformation orderInformation)
    {
        OrderInformation addedOrderInformation = await _orderInformationRepository.AddAsync(orderInformation);

        return addedOrderInformation;
    }

    public async Task<OrderInformation> UpdateAsync(OrderInformation orderInformation)
    {
        OrderInformation updatedOrderInformation = await _orderInformationRepository.UpdateAsync(orderInformation);

        return updatedOrderInformation;
    }

    public async Task<OrderInformation> DeleteAsync(OrderInformation orderInformation, bool permanent = false)
    {
        OrderInformation deletedOrderInformation = await _orderInformationRepository.DeleteAsync(orderInformation);

        return deletedOrderInformation;
    }
}
