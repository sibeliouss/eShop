using Domain.MoneyObject;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderDetails.Queries.GetById;

public class GetByIdOrderDetailResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Money Price { get; set; }
}