using FluentValidation;

namespace Application.Features.ProductDiscounts.Commands.Update;

public class UpdateProductDiscountCommandValidator : AbstractValidator<UpdateProductDiscountCommand>
{
    public UpdateProductDiscountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.DiscountPercentage).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.DiscountPrice).NotEmpty();
    }
}