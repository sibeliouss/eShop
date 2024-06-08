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

namespace Application.Features.Shoppings.Commands.Create;

public class CreateShoppingCommand : IRequest<CreatedShoppingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public Money Price { get; set; }
    public int Quantity { get; set; }

    public string[] Roles => [Admin, Write, ShoppingsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetShoppings"];

    public class CreateShoppingCommandHandler : IRequestHandler<CreateShoppingCommand, CreatedShoppingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingRepository _shoppingRepository;
        private readonly ShoppingBusinessRules _shoppingBusinessRules;

        public CreateShoppingCommandHandler(IMapper mapper, IShoppingRepository shoppingRepository,
                                         ShoppingBusinessRules shoppingBusinessRules)
        {
            _mapper = mapper;
            _shoppingRepository = shoppingRepository;
            _shoppingBusinessRules = shoppingBusinessRules;
        }

        public async Task<CreatedShoppingResponse> Handle(CreateShoppingCommand request, CancellationToken cancellationToken)
        {
            Shopping shopping = _mapper.Map<Shopping>(request);

            await _shoppingRepository.AddAsync(shopping);

            CreatedShoppingResponse response = _mapper.Map<CreatedShoppingResponse>(shopping);
            return response;
        }
    }
}