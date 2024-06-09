using Domain.MoneyObject;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string ImgUrl { get; set; }
    public string? Description { get; set; }
    public string Barcode { get; set; }
    public short Stock { get; set; }
    public Guid CategoryId { get; set; }
    public Money Price { get; set; }
}