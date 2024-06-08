using Application.Features.OrderInformations.Constants;
using Application.Features.OrderInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OrderInformations.Constants.OrderInformationsOperationClaims;

namespace Application.Features.OrderInformations.Commands.Create;

public class CreateOrderInformationCommand : IRequest<CreatedOrderInformationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string OrderNumber { get; set; }
    public OrderStatusEnum? OrderStatusEnum { get; set; }
    public DateTime StatusDate { get; set; }

    public string[] Roles => [Admin, Write, OrderInformationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderInformations"];

    public class CreateOrderInformationCommandHandler : IRequestHandler<CreateOrderInformationCommand, CreatedOrderInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderInformationRepository _orderInformationRepository;
        private readonly OrderInformationBusinessRules _orderInformationBusinessRules;

        public CreateOrderInformationCommandHandler(IMapper mapper, IOrderInformationRepository orderInformationRepository,
                                         OrderInformationBusinessRules orderInformationBusinessRules)
        {
            _mapper = mapper;
            _orderInformationRepository = orderInformationRepository;
            _orderInformationBusinessRules = orderInformationBusinessRules;
        }

        public async Task<CreatedOrderInformationResponse> Handle(CreateOrderInformationCommand request, CancellationToken cancellationToken)
        {
            OrderInformation orderInformation = _mapper.Map<OrderInformation>(request);

            await _orderInformationRepository.AddAsync(orderInformation);

            CreatedOrderInformationResponse response = _mapper.Map<CreatedOrderInformationResponse>(orderInformation);
            return response;
        }
    }
}