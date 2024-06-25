using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.CompleteOrder;

public class CompleteOrderValidator : AbstractValidator<CompleteOrderCommand>
{
    public CompleteOrderValidator()
    {
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
