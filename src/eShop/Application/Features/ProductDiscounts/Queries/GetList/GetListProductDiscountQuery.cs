using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProductDiscounts.Queries.GetList;

public class GetListProductDiscountQuery : IRequest<GetListResponse<GetListProductDiscountListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListProductDiscounts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetProductDiscounts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductDiscountQueryHandler : IRequestHandler<GetListProductDiscountQuery, GetListResponse<GetListProductDiscountListItemDto>>
    {
        private readonly IProductDiscountRepository _productDiscountRepository;
        private readonly IMapper _mapper;

        public GetListProductDiscountQueryHandler(IProductDiscountRepository productDiscountRepository, IMapper mapper)
        {
            _productDiscountRepository = productDiscountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductDiscountListItemDto>> Handle(GetListProductDiscountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductDiscount> productDiscounts = await _productDiscountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductDiscountListItemDto> response = _mapper.Map<GetListResponse<GetListProductDiscountListItemDto>>(productDiscounts);
            return response;
        }
    }
}