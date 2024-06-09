using Application.Features.OrderProducts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.OrderProducts.Commands.Update;

public class UpdateOrderProductCommand : IRequest<UpdatedOrderProductResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderProducts"];

    public class UpdateOrderProductCommandHandler : IRequestHandler<UpdateOrderProductCommand, UpdatedOrderProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly OrderProductBusinessRules _orderProductBusinessRules;

        public UpdateOrderProductCommandHandler(IMapper mapper, IOrderProductRepository orderProductRepository,
                                         OrderProductBusinessRules orderProductBusinessRules)
        {
            _mapper = mapper;
            _orderProductRepository = orderProductRepository;
            _orderProductBusinessRules = orderProductBusinessRules;
        }

        public async Task<UpdatedOrderProductResponse> Handle(UpdateOrderProductCommand request, CancellationToken cancellationToken)
        {
            OrderProduct? orderProduct = await _orderProductRepository.GetAsync(predicate: op => op.Id == request.Id, cancellationToken: cancellationToken);
            await _orderProductBusinessRules.OrderProductShouldExistWhenSelected(orderProduct);
            orderProduct = _mapper.Map(request, orderProduct);

            await _orderProductRepository.UpdateAsync(orderProduct!);

            UpdatedOrderProductResponse response = _mapper.Map<UpdatedOrderProductResponse>(orderProduct);
            return response;
        }
    }
}