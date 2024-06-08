using Application.Features.OrderInformations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.OrderInformations.Constants.OrderInformationsOperationClaims;

namespace Application.Features.OrderInformations.Queries.GetList;

public class GetListOrderInformationQuery : IRequest<GetListResponse<GetListOrderInformationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListOrderInformations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetOrderInformations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrderInformationQueryHandler : IRequestHandler<GetListOrderInformationQuery, GetListResponse<GetListOrderInformationListItemDto>>
    {
        private readonly IOrderInformationRepository _orderInformationRepository;
        private readonly IMapper _mapper;

        public GetListOrderInformationQueryHandler(IOrderInformationRepository orderInformationRepository, IMapper mapper)
        {
            _orderInformationRepository = orderInformationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderInformationListItemDto>> Handle(GetListOrderInformationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrderInformation> orderInformations = await _orderInformationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderInformationListItemDto> response = _mapper.Map<GetListResponse<GetListOrderInformationListItemDto>>(orderInformations);
            return response;
        }
    }
}