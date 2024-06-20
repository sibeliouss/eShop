using Application.Features.ProductDiscounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.ProductDiscounts.Commands.Update;

public class UpdateProductDiscountCommand : IRequest<UpdatedProductDiscountResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPrice { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductDiscounts"];

    public class UpdateProductDiscountCommandHandler : IRequestHandler<UpdateProductDiscountCommand, UpdatedProductDiscountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDiscountRepository _productDiscountRepository;
        private readonly ProductDiscountBusinessRules _productDiscountBusinessRules;

        public UpdateProductDiscountCommandHandler(IMapper mapper, IProductDiscountRepository productDiscountRepository,
                                         ProductDiscountBusinessRules productDiscountBusinessRules)
        {
            _mapper = mapper;
            _productDiscountRepository = productDiscountRepository;
            _productDiscountBusinessRules = productDiscountBusinessRules;
        }

        public async Task<UpdatedProductDiscountResponse> Handle(UpdateProductDiscountCommand request, CancellationToken cancellationToken)
        {
            ProductDiscount? productDiscount = await _productDiscountRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _productDiscountBusinessRules.ProductDiscountShouldExistWhenSelected(productDiscount);
            productDiscount = _mapper.Map(request, productDiscount);

            await _productDiscountRepository.UpdateAsync(productDiscount!);

            UpdatedProductDiscountResponse response = _mapper.Map<UpdatedProductDiscountResponse>(productDiscount);
            return response;
        }
    }
}