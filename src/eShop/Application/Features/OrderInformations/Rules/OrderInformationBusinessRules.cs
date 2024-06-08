using Application.Features.OrderInformations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.OrderInformations.Rules;

public class OrderInformationBusinessRules : BaseBusinessRules
{
    private readonly IOrderInformationRepository _orderInformationRepository;
    private readonly ILocalizationService _localizationService;

    public OrderInformationBusinessRules(IOrderInformationRepository orderInformationRepository, ILocalizationService localizationService)
    {
        _orderInformationRepository = orderInformationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OrderInformationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OrderInformationShouldExistWhenSelected(OrderInformation? orderInformation)
    {
        if (orderInformation == null)
            await throwBusinessException(OrderInformationsBusinessMessages.OrderInformationNotExists);
    }

    public async Task OrderInformationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OrderInformation? orderInformation = await _orderInformationRepository.GetAsync(
            predicate: oi => oi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderInformationShouldExistWhenSelected(orderInformation);
    }
}