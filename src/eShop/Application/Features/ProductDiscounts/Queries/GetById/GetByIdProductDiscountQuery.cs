using Application.Features.ProductDiscounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductDiscounts.Queries.GetById;

public class GetByIdProductDiscountQuery : IRequest<GetByIdProductDiscountResponse>
{
    public Guid Id { get; set; }

    public class GetByIdProductDiscountQueryHandler : IRequestHandler<GetByIdProductDiscountQuery, GetByIdProductDiscountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDiscountRepository _productDiscountRepository;
        private readonly ProductDiscountBusinessRules _productDiscountBusinessRules;

        public GetByIdProductDiscountQueryHandler(IMapper mapper, IProductDiscountRepository productDiscountRepository, ProductDiscountBusinessRules productDiscountBusinessRules)
        {
            _mapper = mapper;
            _productDiscountRepository = productDiscountRepository;
            _productDiscountBusinessRules = productDiscountBusinessRules;
        }

        public async Task<GetByIdProductDiscountResponse> Handle(GetByIdProductDiscountQuery request, CancellationToken cancellationToken)
        {
            ProductDiscount? productDiscount = await _productDiscountRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _productDiscountBusinessRules.ProductDiscountShouldExistWhenSelected(productDiscount);

            GetByIdProductDiscountResponse response = _mapper.Map<GetByIdProductDiscountResponse>(productDiscount);
            return response;
        }
    }
}