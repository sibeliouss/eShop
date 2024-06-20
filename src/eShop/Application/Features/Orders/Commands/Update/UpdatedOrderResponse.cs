using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Update;

public class UpdatedOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public string? OrderNumber { get; set; }
    public Guid? CustomerId { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentNumber { get; set; }
    public string PaymentType { get; set; }
}