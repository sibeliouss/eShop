using Application.Features.ProductDiscounts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ProductDiscounts.Rules;

public class ProductDiscountBusinessRules : BaseBusinessRules
{
    private readonly IProductDiscountRepository _productDiscountRepository;
    private readonly ILocalizationService _localizationService;

    public ProductDiscountBusinessRules(IProductDiscountRepository productDiscountRepository, ILocalizationService localizationService)
    {
        _productDiscountRepository = productDiscountRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ProductDiscountsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ProductDiscountShouldExistWhenSelected(ProductDiscount? productDiscount)
    {
        if (productDiscount == null)
            await throwBusinessException(ProductDiscountsBusinessMessages.ProductDiscountNotExists);
    }

    public async Task ProductDiscountIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductDiscount? productDiscount = await _productDiscountRepository.GetAsync(
            predicate: pd => pd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductDiscountShouldExistWhenSelected(productDiscount);
    }
}