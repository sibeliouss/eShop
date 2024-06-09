using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderProducts.Commands.Create;

public class CreatedOrderProductResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
}