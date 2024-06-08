using FluentValidation;

namespace Application.Features.Shoppings.Commands.Update;

public class UpdateShoppingCommandValidator : AbstractValidator<UpdateShoppingCommand>
{
    public UpdateShoppingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}