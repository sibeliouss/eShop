using Application.Features.Shoppings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Shoppings.Rules;

public class ShoppingBusinessRules : BaseBusinessRules
{
    private readonly IShoppingRepository _shoppingRepository;
    private readonly ILocalizationService _localizationService;

    public ShoppingBusinessRules(IShoppingRepository shoppingRepository, ILocalizationService localizationService)
    {
        _shoppingRepository = shoppingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ShoppingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ShoppingShouldExistWhenSelected(Shopping? shopping)
    {
        if (shopping == null)
            await throwBusinessException(ShoppingsBusinessMessages.ShoppingNotExists);
    }

    public async Task ShoppingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Shopping? shopping = await _shoppingRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShoppingShouldExistWhenSelected(shopping);
    }
}