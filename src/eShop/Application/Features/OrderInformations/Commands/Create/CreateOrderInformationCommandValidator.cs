using FluentValidation;

namespace Application.Features.OrderInformations.Commands.Create;

public class CreateOrderInformationCommandValidator : AbstractValidator<CreateOrderInformationCommand>
{
    public CreateOrderInformationCommandValidator()
    {
        RuleFor(c => c.OrderNumber).NotEmpty();
        RuleFor(c => c.OrderStatusEnum).NotEmpty();
        RuleFor(c => c.StatusDate).NotEmpty();
    }
}