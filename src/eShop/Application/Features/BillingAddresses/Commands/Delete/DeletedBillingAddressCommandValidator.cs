using FluentValidation;

namespace Application.Features.BillingAddresses.Commands.Delete;

public class DeleteBillingAddressCommandValidator : AbstractValidator<DeleteBillingAddressCommand>
{
    public DeleteBillingAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}