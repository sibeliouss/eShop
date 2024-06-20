using Application.Features.ProductDiscounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.ProductDiscounts.Commands.Create;

public class CreateProductDiscountCommand : IRequest<CreatedProductDiscountResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ProductId { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPrice { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductDiscounts"];

    public class CreateProductDiscountCommandHandler : IRequestHandler<CreateProductDiscountCommand, CreatedProductDiscountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDiscountRepository _productDiscountRepository;
        private readonly ProductDiscountBusinessRules _productDiscountBusinessRules;

        public CreateProductDiscountCommandHandler(IMapper mapper, IProductDiscountRepository productDiscountRepository,
                                         ProductDiscountBusinessRules productDiscountBusinessRules)
        {
            _mapper = mapper;
            _productDiscountRepository = productDiscountRepository;
            _productDiscountBusinessRules = productDiscountBusinessRules;
        }

        public async Task<CreatedProductDiscountResponse> Handle(CreateProductDiscountCommand request, CancellationToken cancellationToken)
        {
            ProductDiscount productDiscount = _mapper.Map<ProductDiscount>(request);

            await _productDiscountRepository.AddAsync(productDiscount);

            CreatedProductDiscountResponse response = _mapper.Map<CreatedProductDiscountResponse>(productDiscount);
            return response;
        }
    }
}