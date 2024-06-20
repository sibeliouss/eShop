using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Queries.GetById;

public class GetByIdOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public string? OrderNumber { get; set; }
    public Guid? CustomerId { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentNumber { get; set; }
    public string PaymentType { get; set; }
}