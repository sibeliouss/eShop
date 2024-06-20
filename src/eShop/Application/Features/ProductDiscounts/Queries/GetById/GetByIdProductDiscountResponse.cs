using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductDiscounts.Queries.GetById;

public class GetByIdProductDiscountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPrice { get; set; }
}