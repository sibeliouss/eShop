using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.OrderProducts.Queries.GetList;

public class GetListOrderProductQuery : IRequest<GetListResponse<GetListOrderProductListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListOrderProducts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetOrderProducts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrderProductQueryHandler : IRequestHandler<GetListOrderProductQuery, GetListResponse<GetListOrderProductListItemDto>>
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IMapper _mapper;

        public GetListOrderProductQueryHandler(IOrderProductRepository orderProductRepository, IMapper mapper)
        {
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderProductListItemDto>> Handle(GetListOrderProductQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrderProduct> orderProducts = await _orderProductRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderProductListItemDto> response = _mapper.Map<GetListResponse<GetListOrderProductListItemDto>>(orderProducts);
            return response;
        }
    }
}