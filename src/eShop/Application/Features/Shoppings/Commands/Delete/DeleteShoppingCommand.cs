using Application.Features.Shoppings.Constants;
using Application.Features.Shoppings.Constants;
using Application.Features.Shoppings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Shoppings.Constants.ShoppingsOperationClaims;

namespace Application.Features.Shoppings.Commands.Delete;

public class DeleteShoppingCommand : IRequest<DeletedShoppingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ShoppingsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetShoppings"];

    public class DeleteShoppingCommandHandler : IRequestHandler<DeleteShoppingCommand, DeletedShoppingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingRepository _shoppingRepository;
        private readonly ShoppingBusinessRules _shoppingBusinessRules;

        public DeleteShoppingCommandHandler(IMapper mapper, IShoppingRepository shoppingRepository,
                                         ShoppingBusinessRules shoppingBusinessRules)
        {
            _mapper = mapper;
            _shoppingRepository = shoppingRepository;
            _shoppingBusinessRules = shoppingBusinessRules;
        }

        public async Task<DeletedShoppingResponse> Handle(DeleteShoppingCommand request, CancellationToken cancellationToken)
        {
            Shopping? shopping = await _shoppingRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shoppingBusinessRules.ShoppingShouldExistWhenSelected(shopping);

            await _shoppingRepository.DeleteAsync(shopping!);

            DeletedShoppingResponse response = _mapper.Map<DeletedShoppingResponse>(shopping);
            return response;
        }
    }
}