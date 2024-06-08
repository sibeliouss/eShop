using FluentValidation;

namespace Application.Features.OrderInformations.Commands.Delete;

public class DeleteOrderInformationCommandValidator : AbstractValidator<DeleteOrderInformationCommand>
{
    public DeleteOrderInformationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}