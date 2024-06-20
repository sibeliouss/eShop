using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ProductDiscounts.Queries.GetList;

public class GetListProductDiscountListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPrice { get; set; }
}