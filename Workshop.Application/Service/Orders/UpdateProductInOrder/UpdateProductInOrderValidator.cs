using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.UpdateProductInOrder;

public class UpdateProductInOrderValidator : AbstractValidator<UpdateProductInOrderCommand>
{
    public UpdateProductInOrderValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty().GreaterThan(0);
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
