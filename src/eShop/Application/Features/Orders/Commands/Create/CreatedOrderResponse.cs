using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Create;

public class CreatedOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public string? OrderNumber { get; set; }
    public Guid? CustomerId { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentNumber { get; set; }
    public string PaymentType { get; set; }
}