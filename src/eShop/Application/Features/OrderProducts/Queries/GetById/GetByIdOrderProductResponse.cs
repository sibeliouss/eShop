using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderProducts.Queries.GetById;

public class GetByIdOrderProductResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
}