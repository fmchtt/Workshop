using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.DeleteWork;

public class DeleteWorkInOrderValidator : AbstractValidator<DeleteWorkInOrderCommand>
{
    public DeleteWorkInOrderValidator()
    {
        RuleFor(c => c.WorkId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
