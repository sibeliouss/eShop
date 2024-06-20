using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductDiscounts.Commands.Delete;

public class DeletedProductDiscountResponse : IResponse
{
    public Guid Id { get; set; }
}