using Application.Features.OrderProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderProducts.Queries.GetById;

public class GetByIdOrderProductQuery : IRequest<GetByIdOrderProductResponse>
{
    public Guid Id { get; set; }

    public class GetByIdOrderProductQueryHandler : IRequestHandler<GetByIdOrderProductQuery, GetByIdOrderProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly OrderProductBusinessRules _orderProductBusinessRules;

        public GetByIdOrderProductQueryHandler(IMapper mapper, IOrderProductRepository orderProductRepository, OrderProductBusinessRules orderProductBusinessRules)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
            _orderProductBusinessRules = orderProductBusinessRules;
        }

        public async Task<GetByIdOrderProductResponse> Handle(GetByIdOrderProductQuery request, CancellationToken cancellationToken)
        {
            OrderProduct? orderProduct = await _orderProductRepository.GetAsync(predicate: op => op.Id == request.Id, cancellationToken: cancellationToken);
            await _orderProductBusinessRules.OrderProductShouldExistWhenSelected(orderProduct);

            GetByIdOrderProductResponse response = _mapper.Map<GetByIdOrderProductResponse>(orderProduct);
            return response;
        }
    }
}