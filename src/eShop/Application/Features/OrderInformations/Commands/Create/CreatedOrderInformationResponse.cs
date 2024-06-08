using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderInformations.Commands.Create;

public class CreatedOrderInformationResponse : IResponse
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public OrderStatusEnum? OrderStatusEnum { get; set; }
    public DateTime StatusDate { get; set; }
}