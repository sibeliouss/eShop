using Application.Features.BillingAddresses.Commands.Create;
using Application.Features.BillingAddresses.Commands.Delete;
using Application.Features.BillingAddresses.Commands.Update;
using Application.Features.BillingAddresses.Queries.GetById;
using Application.Features.BillingAddresses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BillingAddresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BillingAddress, CreateBillingAddressCommand>().ReverseMap();
        CreateMap<BillingAddress, CreatedBillingAddressResponse>().ReverseMap();
        CreateMap<BillingAddress, UpdateBillingAddressCommand>().ReverseMap();
        CreateMap<BillingAddress, UpdatedBillingAddressResponse>().ReverseMap();
        CreateMap<BillingAddress, DeleteBillingAddressCommand>().ReverseMap();
        CreateMap<BillingAddress, DeletedBillingAddressResponse>().ReverseMap();
        CreateMap<BillingAddress, GetByIdBillingAddressResponse>().ReverseMap();
        CreateMap<BillingAddress, GetListBillingAddressListItemDto>().ReverseMap();
        CreateMap<IPaginate<BillingAddress>, GetListResponse<GetListBillingAddressListItemDto>>().ReverseMap();
    }
}