using Application.Features.BillingAddresses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BillingAddresses.Rules;

public class BillingAddressBusinessRules : BaseBusinessRules
{
    private readonly IBillingAddressRepository _billingAddressRepository;
    private readonly ILocalizationService _localizationService;

    public BillingAddressBusinessRules(IBillingAddressRepository billingAddressRepository, ILocalizationService localizationService)
    {
        _billingAddressRepository = billingAddressRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BillingAddressesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BillingAddressShouldExistWhenSelected(BillingAddress? billingAddress)
    {
        if (billingAddress == null)
            await throwBusinessException(BillingAddressesBusinessMessages.BillingAddressNotExists);
    }

    public async Task BillingAddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BillingAddress? billingAddress = await _billingAddressRepository.GetAsync(
            predicate: ba => ba.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BillingAddressShouldExistWhenSelected(billingAddress);
    }
}