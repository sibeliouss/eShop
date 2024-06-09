using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderProducts.Commands.Delete;

public class DeletedOrderProductResponse : IResponse
{
    public Guid Id { get; set; }
}