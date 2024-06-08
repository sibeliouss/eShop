using Domain.Enums;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderInformations.Queries.GetList;

public class GetListOrderInformationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public OrderStatusEnum? OrderStatusEnum { get; set; }
    public DateTime StatusDate { get; set; }
}