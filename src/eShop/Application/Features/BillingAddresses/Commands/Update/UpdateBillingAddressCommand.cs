using Application.Features.BillingAddresses.Constants;
using Application.Features.BillingAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BillingAddresses.Constants.BillingAddressesOperationClaims;

namespace Application.Features.BillingAddresses.Commands.Update;

public class UpdateBillingAddressCommand : IRequest<UpdatedBillingAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string? ZipCode { get; set; }
    public string ContactName { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, BillingAddressesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBillingAddresses"];

    public class UpdateBillingAddressCommandHandler : IRequestHandler<UpdateBillingAddressCommand, UpdatedBillingAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillingAddressRepository _billingAddressRepository;
        private readonly BillingAddressBusinessRules _billingAddressBusinessRules;

        public UpdateBillingAddressCommandHandler(IMapper mapper, IBillingAddressRepository billingAddressRepository,
                                         BillingAddressBusinessRules billingAddressBusinessRules)
        {
            _mapper = mapper;
            _billingAddressRepository = billingAddressRepository;
            _billingAddressBusinessRules = billingAddressBusinessRules;
        }

        public async Task<UpdatedBillingAddressResponse> Handle(UpdateBillingAddressCommand request, CancellationToken cancellationToken)
        {
            BillingAddress? billingAddress = await _billingAddressRepository.GetAsync(predicate: ba => ba.Id == request.Id, cancellationToken: cancellationToken);
            await _billingAddressBusinessRules.BillingAddressShouldExistWhenSelected(billingAddress);
            billingAddress = _mapper.Map(request, billingAddress);

            await _billingAddressRepository.UpdateAsync(billingAddress!);

            UpdatedBillingAddressResponse response = _mapper.Map<UpdatedBillingAddressResponse>(billingAddress);
            return response;
        }
    }
}