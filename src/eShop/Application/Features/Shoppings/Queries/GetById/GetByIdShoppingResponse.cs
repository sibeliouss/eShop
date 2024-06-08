using Domain.MoneyObject;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Shoppings.Queries.GetById;

public class GetByIdShoppingResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public Money Price { get; set; }
    public int Quantity { get; set; }
}