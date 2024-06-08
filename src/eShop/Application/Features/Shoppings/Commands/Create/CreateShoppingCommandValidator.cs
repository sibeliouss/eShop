using FluentValidation;

namespace Application.Features.Shoppings.Commands.Create;

public class CreateShoppingCommandValidator : AbstractValidator<CreateShoppingCommand>
{
    public CreateShoppingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}