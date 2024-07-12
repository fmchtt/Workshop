using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.UpdateWork;

public class UpdateWorkValidator : AbstractValidator<UpdateWorkCommand>
{
    public UpdateWorkValidator()
    {
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.TimeToFinish).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
