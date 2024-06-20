using Application.Features.ProductDiscounts.Commands.Create;
using Application.Features.ProductDiscounts.Commands.Delete;
using Application.Features.ProductDiscounts.Commands.Update;
using Application.Features.ProductDiscounts.Queries.GetById;
using Application.Features.ProductDiscounts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ProductDiscounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductDiscount, CreateProductDiscountCommand>().ReverseMap();
        CreateMap<ProductDiscount, CreatedProductDiscountResponse>().ReverseMap();
        CreateMap<ProductDiscount, UpdateProductDiscountCommand>().ReverseMap();
        CreateMap<ProductDiscount, UpdatedProductDiscountResponse>().ReverseMap();
        CreateMap<ProductDiscount, DeleteProductDiscountCommand>().ReverseMap();
        CreateMap<ProductDiscount, DeletedProductDiscountResponse>().ReverseMap();
        CreateMap<ProductDiscount, GetByIdProductDiscountResponse>().ReverseMap();
        CreateMap<ProductDiscount, GetListProductDiscountListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProductDiscount>, GetListResponse<GetListProductDiscountListItemDto>>().ReverseMap();
    }
}