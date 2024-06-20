using Application.Features.BillingAddresses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BillingAddresses;

public class BillingAddressManager : IBillingAddressService
{
    private readonly IBillingAddressRepository _billingAddressRepository;
    private readonly BillingAddressBusinessRules _billingAddressBusinessRules;

    public BillingAddressManager(IBillingAddressRepository billingAddressRepository, BillingAddressBusinessRules billingAddressBusinessRules)
    {
        _billingAddressRepository = billingAddressRepository;
        _billingAddressBusinessRules = billingAddressBusinessRules;
    }

    public async Task<BillingAddress?> GetAsync(
        Expression<Func<BillingAddress, bool>> predicate,
        Func<IQueryable<BillingAddress>, IIncludableQueryable<BillingAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BillingAddress? billingAddress = await _billingAddressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return billingAddress;
    }

    public async Task<IPaginate<BillingAddress>?> GetListAsync(
        Expression<Func<BillingAddress, bool>>? predicate = null,
        Func<IQueryable<BillingAddress>, IOrderedQueryable<BillingAddress>>? orderBy = null,
        Func<IQueryable<BillingAddress>, IIncludableQueryable<BillingAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BillingAddress> billingAddressList = await _billingAddressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return billingAddressList;
    }

    public async Task<BillingAddress> AddAsync(BillingAddress billingAddress)
    {
        BillingAddress addedBillingAddress = await _billingAddressRepository.AddAsync(billingAddress);

        return addedBillingAddress;
    }

    public async Task<BillingAddress> UpdateAsync(BillingAddress billingAddress)
    {
        BillingAddress updatedBillingAddress = await _billingAddressRepository.UpdateAsync(billingAddress);

        return updatedBillingAddress;
    }

    public async Task<BillingAddress> DeleteAsync(BillingAddress billingAddress, bool permanent = false)
    {
        BillingAddress deletedBillingAddress = await _billingAddressRepository.DeleteAsync(billingAddress);

        return deletedBillingAddress;
    }
}
