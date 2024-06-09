using Application.Features.OrderProducts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.OrderProducts.Rules;

public class OrderProductBusinessRules : BaseBusinessRules
{
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly ILocalizationService _localizationService;

    public OrderProductBusinessRules(IOrderProductRepository orderProductRepository, ILocalizationService localizationService)
    {
        _orderProductRepository = orderProductRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OrderProductsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OrderProductShouldExistWhenSelected(OrderProduct? orderProduct)
    {
        if (orderProduct == null)
            await throwBusinessException(OrderProductsBusinessMessages.OrderProductNotExists);
    }

    public async Task OrderProductIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OrderProduct? orderProduct = await _orderProductRepository.GetAsync(
            predicate: op => op.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderProductShouldExistWhenSelected(orderProduct);
    }
}