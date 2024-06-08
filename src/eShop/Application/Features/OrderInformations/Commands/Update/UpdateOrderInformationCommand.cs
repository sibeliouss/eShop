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

namespace Application.Features.OrderInformations.Commands.Update;

public class UpdateOrderInformationCommand : IRequest<UpdatedOrderInformationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public OrderStatusEnum? OrderStatusEnum { get; set; }
    public DateTime StatusDate { get; set; }

    public string[] Roles => [Admin, Write, OrderInformationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderInformations"];

    public class UpdateOrderInformationCommandHandler : IRequestHandler<UpdateOrderInformationCommand, UpdatedOrderInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderInformationRepository _orderInformationRepository;
        private readonly OrderInformationBusinessRules _orderInformationBusinessRules;

        public UpdateOrderInformationCommandHandler(IMapper mapper, IOrderInformationRepository orderInformationRepository,
                                         OrderInformationBusinessRules orderInformationBusinessRules)
        {
            _mapper = mapper;
            _orderInformationRepository = orderInformationRepository;
            _orderInformationBusinessRules = orderInformationBusinessRules;
        }

        public async Task<UpdatedOrderInformationResponse> Handle(UpdateOrderInformationCommand request, CancellationToken cancellationToken)
        {
            OrderInformation? orderInformation = await _orderInformationRepository.GetAsync(predicate: oi => oi.Id == request.Id, cancellationToken: cancellationToken);
            await _orderInformationBusinessRules.OrderInformationShouldExistWhenSelected(orderInformation);
            orderInformation = _mapper.Map(request, orderInformation);

            await _orderInformationRepository.UpdateAsync(orderInformation!);

            UpdatedOrderInformationResponse response = _mapper.Map<UpdatedOrderInformationResponse>(orderInformation);
            return response;
        }
    }
}