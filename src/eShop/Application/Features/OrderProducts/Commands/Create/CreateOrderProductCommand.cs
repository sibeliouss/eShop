using Application.Features.OrderProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.OrderProducts.Commands.Create;

public class CreateOrderProductCommand : IRequest<CreatedOrderProductResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderProducts"];

    public class CreateOrderProductCommandHandler : IRequestHandler<CreateOrderProductCommand, CreatedOrderProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly OrderProductBusinessRules _orderProductBusinessRules;

        public CreateOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository,
                                         OrderProductBusinessRules orderProductBusinessRules)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
            _orderProductBusinessRules = orderProductBusinessRules;
        }

        public async Task<CreatedOrderProductResponse> Handle(CreateOrderProductCommand request, CancellationToken cancellationToken)
        {
            OrderProduct orderProduct = _mapper.Map<OrderProduct>(request);

            await _orderProductRepository.AddAsync(orderProduct);

            CreatedOrderProductResponse response = _mapper.Map<CreatedOrderProductResponse>(orderProduct);
            return response;
        }
    }
}