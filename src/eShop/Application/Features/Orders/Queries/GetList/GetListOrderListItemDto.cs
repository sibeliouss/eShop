using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? OrderNumber { get; set; }
    public Guid? CustomerId { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentNumber { get; set; }
    public string PaymentType { get; set; }
}