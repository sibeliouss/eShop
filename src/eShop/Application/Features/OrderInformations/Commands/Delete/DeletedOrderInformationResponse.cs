using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderInformations.Commands.Delete;

public class DeletedOrderInformationResponse : IResponse
{
    public Guid Id { get; set; }
}