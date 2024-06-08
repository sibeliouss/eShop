using Domain.MoneyObject;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductListItemDto : IDto
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
    public Guid OrderId { get; set; }
}