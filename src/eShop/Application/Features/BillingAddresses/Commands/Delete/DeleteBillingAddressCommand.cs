using Application.Features.BillingAddresses.Constants;
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

namespace Application.Features.BillingAddresses.Commands.Delete;

public class DeleteBillingAddressCommand : IRequest<DeletedBillingAddressResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BillingAddressesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBillingAddresses"];

    public class DeleteBillingAddressCommandHandler : IRequestHandler<DeleteBillingAddressCommand, DeletedBillingAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBillingAddressRepository _billingAddressRepository;
        private readonly BillingAddressBusinessRules _billingAddressBusinessRules;

        public DeleteBillingAddressCommandHandler(IMapper mapper, IBillingAddressRepository billingAddressRepository,
                                         BillingAddressBusinessRules billingAddressBusinessRules)
        {
            _mapper = mapper;
            _billingAddressRepository = billingAddressRepository;
            _billingAddressBusinessRules = billingAddressBusinessRules;
        }

        public async Task<DeletedBillingAddressResponse> Handle(DeleteBillingAddressCommand request, CancellationToken cancellationToken)
        {
            BillingAddress? billingAddress = await _billingAddressRepository.GetAsync(predicate: ba => ba.Id == request.Id, cancellationToken: cancellationToken);
            await _billingAddressBusinessRules.BillingAddressShouldExistWhenSelected(billingAddress);

            await _billingAddressRepository.DeleteAsync(billingAddress!);

            DeletedBillingAddressResponse response = _mapper.Map<DeletedBillingAddressResponse>(billingAddress);
            return response;
        }
    }
}