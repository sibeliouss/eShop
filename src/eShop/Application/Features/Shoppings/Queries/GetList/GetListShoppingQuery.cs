using Application.Features.Shoppings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Shoppings.Constants.ShoppingsOperationClaims;

namespace Application.Features.Shoppings.Queries.GetList;

public class GetListShoppingQuery : IRequest<GetListResponse<GetListShoppingListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListShoppings({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetShoppings";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListShoppingQueryHandler : IRequestHandler<GetListShoppingQuery, GetListResponse<GetListShoppingListItemDto>>
    {
        private readonly IShoppingRepository _shoppingRepository;
        private readonly IMapper _mapper;

        public GetListShoppingQueryHandler(IShoppingRepository shoppingRepository, IMapper mapper)
        {
            _shoppingRepository = shoppingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListShoppingListItemDto>> Handle(GetListShoppingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Shopping> shoppings = await _shoppingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListShoppingListItemDto> response = _mapper.Map<GetListResponse<GetListShoppingListItemDto>>(shoppings);
            return response;
        }
    }
}