using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderProducts.Queries.GetList;

public class GetListOrderProductListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
}