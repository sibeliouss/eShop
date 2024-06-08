using Application.Features.Shoppings.Constants;
using Application.Features.Shoppings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.MoneyObject;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Shoppings.Constants.ShoppingsOperationClaims;

namespace Application.Features.Shoppings.Commands.Update;

public class UpdateShoppingCommand : IRequest<UpdatedShoppingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public Money Price { get; set; }
    public int Quantity { get; set; }

    public string[] Roles => [Admin, Write, ShoppingsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetShoppings"];

    public class UpdateShoppingCommandHandler : IRequestHandler<UpdateShoppingCommand, UpdatedShoppingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingRepository _shoppingRepository;
        private readonly ShoppingBusinessRules _shoppingBusinessRules;

        public UpdateShoppingCommandHandler(IMapper mapper, IShoppingRepository shoppingRepository,
                                         ShoppingBusinessRules shoppingBusinessRules)
        {
            _mapper = mapper;
            _shoppingRepository = shoppingRepository;
            _shoppingBusinessRules = shoppingBusinessRules;
        }

        public async Task<UpdatedShoppingResponse> Handle(UpdateShoppingCommand request, CancellationToken cancellationToken)
        {
            Shopping? shopping = await _shoppingRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shoppingBusinessRules.ShoppingShouldExistWhenSelected(shopping);
            shopping = _mapper.Map(request, shopping);

            await _shoppingRepository.UpdateAsync(shopping!);

            UpdatedShoppingResponse response = _mapper.Map<UpdatedShoppingResponse>(shopping);
            return response;
        }
    }
}