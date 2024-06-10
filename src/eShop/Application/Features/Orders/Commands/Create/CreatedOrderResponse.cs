using Domain.MoneyObject;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Create;

public class CreatedOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Money Price { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentNumber { get; set; }
    public string PaymentType { get; set; }
}