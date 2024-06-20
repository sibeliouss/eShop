using FluentValidation;

namespace Application.Features.ProductDiscounts.Commands.Delete;

public class DeleteProductDiscountCommandValidator : AbstractValidator<DeleteProductDiscountCommand>
{
    public DeleteProductDiscountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}