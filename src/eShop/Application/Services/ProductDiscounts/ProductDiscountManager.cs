using Application.Features.ProductDiscounts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductDiscounts;

public class ProductDiscountManager : IProductDiscountService
{
    private readonly IProductDiscountRepository _productDiscountRepository;
    private readonly ProductDiscountBusinessRules _productDiscountBusinessRules;

    public ProductDiscountManager(IProductDiscountRepository productDiscountRepository, ProductDiscountBusinessRules productDiscountBusinessRules)
    {
        _productDiscountRepository = productDiscountRepository;
        _productDiscountBusinessRules = productDiscountBusinessRules;
    }

    public async Task<ProductDiscount?> GetAsync(
        Expression<Func<ProductDiscount, bool>> predicate,
        Func<IQueryable<ProductDiscount>, IIncludableQueryable<ProductDiscount, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductDiscount? productDiscount = await _productDiscountRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productDiscount;
    }

    public async Task<IPaginate<ProductDiscount>?> GetListAsync(
        Expression<Func<ProductDiscount, bool>>? predicate = null,
        Func<IQueryable<ProductDiscount>, IOrderedQueryable<ProductDiscount>>? orderBy = null,
        Func<IQueryable<ProductDiscount>, IIncludableQueryable<ProductDiscount, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductDiscount> productDiscountList = await _productDiscountRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productDiscountList;
    }

    public async Task<ProductDiscount> AddAsync(ProductDiscount productDiscount)
    {
        ProductDiscount addedProductDiscount = await _productDiscountRepository.AddAsync(productDiscount);

        return addedProductDiscount;
    }

    public async Task<ProductDiscount> UpdateAsync(ProductDiscount productDiscount)
    {
        ProductDiscount updatedProductDiscount = await _productDiscountRepository.UpdateAsync(productDiscount);

        return updatedProductDiscount;
    }

    public async Task<ProductDiscount> DeleteAsync(ProductDiscount productDiscount, bool permanent = false)
    {
        ProductDiscount deletedProductDiscount = await _productDiscountRepository.DeleteAsync(productDiscount);

        return deletedProductDiscount;
    }
}
