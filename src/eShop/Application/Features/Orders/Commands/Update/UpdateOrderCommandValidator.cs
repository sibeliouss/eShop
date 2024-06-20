using FluentValidation;

namespace Application.Features.Orders.Commands.Update;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OrderNumber).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.PaymentDate).NotEmpty();
        RuleFor(c => c.PaymentNumber).NotEmpty();
        RuleFor(c => c.PaymentType).NotEmpty();
    }
}