using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.DeleteProductInOrder;

public class DeleteProductInOrderValidator : AbstractValidator<DeleteProductInOrderCommand>
{
    public DeleteProductInOrderValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
