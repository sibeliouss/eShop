using NArchitecture.Core.Application.Responses;

namespace Application.Features.BillingAddresses.Commands.Delete;

public class DeletedBillingAddressResponse : IResponse
{
    public Guid Id { get; set; }
}