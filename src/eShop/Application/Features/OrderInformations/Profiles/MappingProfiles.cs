using Application.Features.OrderInformations.Commands.Create;
using Application.Features.OrderInformations.Commands.Delete;
using Application.Features.OrderInformations.Commands.Update;
using Application.Features.OrderInformations.Queries.GetById;
using Application.Features.OrderInformations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OrderInformations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OrderInformation, CreateOrderInformationCommand>().ReverseMap();
        CreateMap<OrderInformation, CreatedOrderInformationResponse>().ReverseMap();
        CreateMap<OrderInformation, UpdateOrderInformationCommand>().ReverseMap();
        CreateMap<OrderInformation, UpdatedOrderInformationResponse>().ReverseMap();
        CreateMap<OrderInformation, DeleteOrderInformationCommand>().ReverseMap();
        CreateMap<OrderInformation, DeletedOrderInformationResponse>().ReverseMap();
        CreateMap<OrderInformation, GetByIdOrderInformationResponse>().ReverseMap();
        CreateMap<OrderInformation, GetListOrderInformationListItemDto>().ReverseMap();
        CreateMap<IPaginate<OrderInformation>, GetListResponse<GetListOrderInformationListItemDto>>().ReverseMap();
    }
}