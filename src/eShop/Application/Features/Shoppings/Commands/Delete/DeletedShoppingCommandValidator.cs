using FluentValidation;

namespace Application.Features.Shoppings.Commands.Delete;

public class DeleteShoppingCommandValidator : AbstractValidator<DeleteShoppingCommand>
{
    public DeleteShoppingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}