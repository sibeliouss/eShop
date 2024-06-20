using Application.Features.BillingAddresses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BillingAddresses.Constants.BillingAddressesOperationClaims;

namespace Application.Features.BillingAddresses.Queries.GetList;

public class GetListBillingAddressQuery : IRequest<GetListResponse<GetListBillingAddressListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBillingAddresses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBillingAddresses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBillingAddressQueryHandler : IRequestHandler<GetListBillingAddressQuery, GetListResponse<GetListBillingAddressListItemDto>>
    {
        private readonly IBillingAddressRepository _billingAddressRepository;
        private readonly IMapper _mapper;

        public GetListBillingAddressQueryHandler(IBillingAddressRepository billingAddressRepository, IMapper mapper)
        {
            _billingAddressRepository = billingAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBillingAddressListItemDto>> Handle(GetListBillingAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BillingAddress> billingAddresses = await _billingAddressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBillingAddressListItemDto> response = _mapper.Map<GetListResponse<GetListBillingAddressListItemDto>>(billingAddresses);
            return response;
        }
    }
}