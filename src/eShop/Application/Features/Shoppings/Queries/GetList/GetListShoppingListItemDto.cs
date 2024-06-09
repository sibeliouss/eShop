using Domain.MoneyObject;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Shoppings.Queries.GetList;

public class GetListShoppingListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public Money Price { get; set; }
    public int Quantity { get; set; }
}