using Application.Features.Shoppings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shoppings;

public class ShoppingManager : IShoppingService
{
    private readonly IShoppingRepository _shoppingRepository;
    private readonly ShoppingBusinessRules _shoppingBusinessRules;

    public ShoppingManager(IShoppingRepository shoppingRepository, ShoppingBusinessRules shoppingBusinessRules)
    {
        _shoppingRepository = shoppingRepository;
        _shoppingBusinessRules = shoppingBusinessRules;
    }

    public async Task<Shopping?> GetAsync(
        Expression<Func<Shopping, bool>> predicate,
        Func<IQueryable<Shopping>, IIncludableQueryable<Shopping, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Shopping? shopping = await _shoppingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shopping;
    }

    public async Task<IPaginate<Shopping>?> GetListAsync(
        Expression<Func<Shopping, bool>>? predicate = null,
        Func<IQueryable<Shopping>, IOrderedQueryable<Shopping>>? orderBy = null,
        Func<IQueryable<Shopping>, IIncludableQueryable<Shopping, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Shopping> shoppingList = await _shoppingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shoppingList;
    }

    public async Task<Shopping> AddAsync(Shopping shopping)
    {
        Shopping addedShopping = await _shoppingRepository.AddAsync(shopping);

        return addedShopping;
    }

    public async Task<Shopping> UpdateAsync(Shopping shopping)
    {
        Shopping updatedShopping = await _shoppingRepository.UpdateAsync(shopping);

        return updatedShopping;
    }

    public async Task<Shopping> DeleteAsync(Shopping shopping, bool permanent = false)
    {
        Shopping deletedShopping = await _shoppingRepository.DeleteAsync(shopping);

        return deletedShopping;
    }
}
