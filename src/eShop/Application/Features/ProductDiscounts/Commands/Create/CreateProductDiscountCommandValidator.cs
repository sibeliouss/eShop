using FluentValidation;

namespace Application.Features.ProductDiscounts.Commands.Create;

public class CreateProductDiscountCommandValidator : AbstractValidator<CreateProductDiscountCommand>
{
    public CreateProductDiscountCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.DiscountPercentage).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.DiscountPrice).NotEmpty();
    }
}