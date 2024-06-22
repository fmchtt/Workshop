using FluentValidation;

namespace Workshop.Application.Service.Orders.Create;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(c => c.ClientId).NotEmpty();
        RuleFor(c => c.EmployeeId).NotEmpty();
        RuleFor(c => c.Actor).NotNull();
    }
}
