using FluentValidation;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.OrderNumber).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.PaymentDate).NotEmpty();
        RuleFor(c => c.PaymentNumber).NotEmpty();
        RuleFor(c => c.PaymentType).NotEmpty();
    }
}