using NArchitecture.Core.Application.Responses;

namespace Application.Features.Shoppings.Commands.Delete;

public class DeletedShoppingResponse : IResponse
{
    public Guid Id { get; set; }
}