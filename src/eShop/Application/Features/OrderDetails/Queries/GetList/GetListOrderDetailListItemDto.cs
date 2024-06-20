using Domain.MoneyObject;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderDetails.Queries.GetList;

public class GetListOrderDetailListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Money Price { get; set; }
}