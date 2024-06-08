using Application.Features.Shoppings.Commands.Create;
using Application.Features.Shoppings.Commands.Delete;
using Application.Features.Shoppings.Commands.Update;
using Application.Features.Shoppings.Queries.GetById;
using Application.Features.Shoppings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Shoppings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Shopping, CreateShoppingCommand>().ReverseMap();
        CreateMap<Shopping, CreatedShoppingResponse>().ReverseMap();
        CreateMap<Shopping, UpdateShoppingCommand>().ReverseMap();
        CreateMap<Shopping, UpdatedShoppingResponse>().ReverseMap();
        CreateMap<Shopping, DeleteShoppingCommand>().ReverseMap();
        CreateMap<Shopping, DeletedShoppingResponse>().ReverseMap();
        CreateMap<Shopping, GetByIdShoppingResponse>().ReverseMap();
        CreateMap<Shopping, GetListShoppingListItemDto>().ReverseMap();
        CreateMap<IPaginate<Shopping>, GetListResponse<GetListShoppingListItemDto>>().ReverseMap();
    }
}