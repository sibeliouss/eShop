using FluentValidation;

namespace Application.Features.BillingAddresses.Commands.Create;

public class CreateBillingAddressCommandValidator : AbstractValidator<CreateBillingAddressCommand>
{
    public CreateBillingAddressCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.ZipCode).NotEmpty();
        RuleFor(c => c.ContactName).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}