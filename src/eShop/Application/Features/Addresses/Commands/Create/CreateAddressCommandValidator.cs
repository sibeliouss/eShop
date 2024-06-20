using FluentValidation;

namespace Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.ZipCode).NotEmpty();
        RuleFor(c => c.ContactName).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}