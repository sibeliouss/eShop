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

namespace Application.Features.BillingAddresses.Commands.Create;

public class CreateBillingAddressCommand : IRequest<CreatedBillingAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CustomerId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string? ZipCode { get; set; }
    public string ContactName { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, BillingAddressesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBillingAddresses"];

    public class CreateBillingAddressCommandHandler : IRequestHandler<CreateBillingAddressCommand, CreatedBillingAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillingAddressRepository _billingAddressRepository;
        private readonly BillingAddressBusinessRules _billingAddressBusinessRules;

        public CreateBillingAddressCommandHandler(IMapper mapper, IBillingAddressRepository billingAddressRepository,
                                         BillingAddressBusinessRules billingAddressBusinessRules)
        {
            _mapper = mapper;
            _billingAddressRepository = billingAddressRepository;
            _billingAddressBusinessRules = billingAddressBusinessRules;
        }

        public async Task<CreatedBillingAddressResponse> Handle(CreateBillingAddressCommand request, CancellationToken cancellationToken)
        {
            BillingAddress billingAddress = _mapper.Map<BillingAddress>(request);

            await _billingAddressRepository.AddAsync(billingAddress);

            CreatedBillingAddressResponse response = _mapper.Map<CreatedBillingAddressResponse>(billingAddress);
            return response;
        }
    }
}