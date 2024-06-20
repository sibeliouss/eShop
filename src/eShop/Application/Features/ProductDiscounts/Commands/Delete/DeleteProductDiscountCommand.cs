using Application.Features.ProductDiscounts.Constants;
using Application.Features.ProductDiscounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.ProductDiscounts.Commands.Delete;

public class DeleteProductDiscountCommand : IRequest<DeletedProductDiscountResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductDiscounts"];

    public class DeleteProductDiscountCommandHandler : IRequestHandler<DeleteProductDiscountCommand, DeletedProductDiscountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDiscountRepository _productDiscountRepository;
        private readonly ProductDiscountBusinessRules _productDiscountBusinessRules;

        public DeleteProductDiscountCommandHandler(IMapper mapper, IProductDiscountRepository productDiscountRepository,
                                         ProductDiscountBusinessRules productDiscountBusinessRules)
        {
            _mapper = mapper;
            _productDiscountRepository = productDiscountRepository;
            _productDiscountBusinessRules = productDiscountBusinessRules;
        }

        public async Task<DeletedProductDiscountResponse> Handle(DeleteProductDiscountCommand request, CancellationToken cancellationToken)
        {
            ProductDiscount? productDiscount = await _productDiscountRepository.GetAsync(predicate: pd => pd.Id == request.Id, cancellationToken: cancellationToken);
            await _productDiscountBusinessRules.ProductDiscountShouldExistWhenSelected(productDiscount);

            await _productDiscountRepository.DeleteAsync(productDiscount!);

            DeletedProductDiscountResponse response = _mapper.Map<DeletedProductDiscountResponse>(productDiscount);
            return response;
        }
    }
}