using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.UpdateWork;

public class UpdateWorkInOrderValidator : AbstractValidator<UpdateWorkInOrderCommand>
{
    public UpdateWorkInOrderValidator()
    {
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
        RuleFor(c => c.DateFinish).NotEmpty();
        RuleFor(c => c.DateInit).NotEmpty();
        RuleFor(c => c.WorkId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
