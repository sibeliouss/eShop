using Application.Features.Shoppings.Constants;
using Application.Features.Shoppings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Shoppings.Constants.ShoppingsOperationClaims;

namespace Application.Features.Shoppings.Queries.GetById;

public class GetByIdShoppingQuery : IRequest<GetByIdShoppingResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdShoppingQueryHandler : IRequestHandler<GetByIdShoppingQuery, GetByIdShoppingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingRepository _shoppingRepository;
        private readonly ShoppingBusinessRules _shoppingBusinessRules;

        public GetByIdShoppingQueryHandler(IMapper mapper, IShoppingRepository shoppingRepository, ShoppingBusinessRules shoppingBusinessRules)
        {
            _mapper = mapper;
            _shoppingRepository = shoppingRepository;
            _shoppingBusinessRules = shoppingBusinessRules;
        }

        public async Task<GetByIdShoppingResponse> Handle(GetByIdShoppingQuery request, CancellationToken cancellationToken)
        {
            Shopping? shopping = await _shoppingRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _shoppingBusinessRules.ShoppingShouldExistWhenSelected(shopping);

            GetByIdShoppingResponse response = _mapper.Map<GetByIdShoppingResponse>(shopping);
            return response;
        }
    }
}