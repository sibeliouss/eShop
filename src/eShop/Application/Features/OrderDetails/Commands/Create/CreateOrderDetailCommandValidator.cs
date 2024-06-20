using FluentValidation;

namespace Application.Features.OrderDetails.Commands.Create;

public class CreateOrderDetailCommandValidator : AbstractValidator<CreateOrderDetailCommand>
{
    public CreateOrderDetailCommandValidator()
    {
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
    }
}