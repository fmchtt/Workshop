using FluentValidation;

namespace Workshop.Application.Service.Orders.CreateWork;

public class CreateWorkInOrderValidator : AbstractValidator<CreateWorkInOrderCommand>
{
    public CreateWorkInOrderValidator()
    {
        RuleFor(c => c.Price).NotEmpty().GreaterThan(0);
        RuleFor(c => c.DateFinish).NotEmpty();
        RuleFor(c => c.DateInit).NotEmpty();
        RuleFor(c => c.WorkId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull();
    }
}
