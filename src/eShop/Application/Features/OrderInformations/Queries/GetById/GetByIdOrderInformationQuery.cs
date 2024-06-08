using Application.Features.OrderInformations.Constants;
using Application.Features.OrderInformations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.OrderInformations.Constants.OrderInformationsOperationClaims;

namespace Application.Features.OrderInformations.Queries.GetById;

public class GetByIdOrderInformationQuery : IRequest<GetByIdOrderInformationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdOrderInformationQueryHandler : IRequestHandler<GetByIdOrderInformationQuery, GetByIdOrderInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderInformationRepository _orderInformationRepository;
        private readonly OrderInformationBusinessRules _orderInformationBusinessRules;

        public GetByIdOrderInformationQueryHandler(IMapper mapper, IOrderInformationRepository orderInformationRepository, OrderInformationBusinessRules orderInformationBusinessRules)
        {
            _mapper = mapper;
            _orderInformationRepository = orderInformationRepository;
            _orderInformationBusinessRules = orderInformationBusinessRules;
        }

        public async Task<GetByIdOrderInformationResponse> Handle(GetByIdOrderInformationQuery request, CancellationToken cancellationToken)
        {
            OrderInformation? orderInformation = await _orderInformationRepository.GetAsync(predicate: oi => oi.Id == request.Id, cancellationToken: cancellationToken);
            await _orderInformationBusinessRules.OrderInformationShouldExistWhenSelected(orderInformation);

            GetByIdOrderInformationResponse response = _mapper.Map<GetByIdOrderInformationResponse>(orderInformation);
            return response;
        }
    }
}