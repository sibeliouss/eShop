using Application.Features.OrderInformations.Constants;
using Application.Features.OrderInformations.Constants;
using Application.Features.OrderInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OrderInformations.Constants.OrderInformationsOperationClaims;

namespace Application.Features.OrderInformations.Commands.Delete;

public class DeleteOrderInformationCommand : IRequest<DeletedOrderInformationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, OrderInformationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderInformations"];

    public class DeleteOrderInformationCommandHandler : IRequestHandler<DeleteOrderInformationCommand, DeletedOrderInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderInformationRepository _orderInformationRepository;
        private readonly OrderInformationBusinessRules _orderInformationBusinessRules;

        public DeleteOrderInformationCommandHandler(IMapper mapper, IOrderInformationRepository orderInformationRepository,
                                         OrderInformationBusinessRules orderInformationBusinessRules)
        {
            _mapper = mapper;
            _orderInformationRepository = orderInformationRepository;
            _orderInformationBusinessRules = orderInformationBusinessRules;
        }

        public async Task<DeletedOrderInformationResponse> Handle(DeleteOrderInformationCommand request, CancellationToken cancellationToken)
        {
            OrderInformation? orderInformation = await _orderInformationRepository.GetAsync(predicate: oi => oi.Id == request.Id, cancellationToken: cancellationToken);
            await _orderInformationBusinessRules.OrderInformationShouldExistWhenSelected(orderInformation);

            await _orderInformationRepository.DeleteAsync(orderInformation!);

            DeletedOrderInformationResponse response = _mapper.Map<DeletedOrderInformationResponse>(orderInformation);
            return response;
        }
    }
}