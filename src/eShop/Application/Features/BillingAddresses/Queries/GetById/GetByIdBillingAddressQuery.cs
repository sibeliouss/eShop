using Application.Features.BillingAddresses.Constants;
using Application.Features.BillingAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BillingAddresses.Constants.BillingAddressesOperationClaims;

namespace Application.Features.BillingAddresses.Queries.GetById;

public class GetByIdBillingAddressQuery : IRequest<GetByIdBillingAddressResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBillingAddressQueryHandler : IRequestHandler<GetByIdBillingAddressQuery, GetByIdBillingAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillingAddressRepository _billingAddressRepository;
        private readonly BillingAddressBusinessRules _billingAddressBusinessRules;

        public GetByIdBillingAddressQueryHandler(IMapper mapper, IBillingAddressRepository billingAddressRepository, BillingAddressBusinessRules billingAddressBusinessRules)
        {
            _mapper = mapper;
            _billingAddressRepository = billingAddressRepository;
            _billingAddressBusinessRules = billingAddressBusinessRules;
        }

        public async Task<GetByIdBillingAddressResponse> Handle(GetByIdBillingAddressQuery request, CancellationToken cancellationToken)
        {
            BillingAddress? billingAddress = await _billingAddressRepository.GetAsync(predicate: ba => ba.Id == request.Id, cancellationToken: cancellationToken);
            await _billingAddressBusinessRules.BillingAddressShouldExistWhenSelected(billingAddress);

            GetByIdBillingAddressResponse response = _mapper.Map<GetByIdBillingAddressResponse>(billingAddress);
            return response;
        }
    }
}