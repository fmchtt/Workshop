using FluentValidation;

namespace Workshop.Application.Service.Orders.CreateWork;

public class CreateWorkValidator : AbstractValidator<CreateWorkCommand>
{
    public CreateWorkValidator()
    {
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.TimeToFinish).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull();
    }
}
