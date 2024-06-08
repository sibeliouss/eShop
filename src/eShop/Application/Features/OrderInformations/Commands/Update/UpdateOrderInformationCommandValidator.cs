using FluentValidation;

namespace Application.Features.OrderInformations.Commands.Update;

public class UpdateOrderInformationCommandValidator : AbstractValidator<UpdateOrderInformationCommand>
{
    public UpdateOrderInformationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OrderNumber).NotEmpty();
        RuleFor(c => c.OrderStatusEnum).NotEmpty();
        RuleFor(c => c.StatusDate).NotEmpty();
    }
}