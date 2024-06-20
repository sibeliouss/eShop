using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductDiscounts.Commands.Create;

public class CreatedProductDiscountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountPrice { get; set; }
}