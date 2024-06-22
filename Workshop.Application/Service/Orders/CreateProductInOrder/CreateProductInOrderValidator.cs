using FluentValidation;

namespace Workshop.Application.Service.Orders.CreateProductInOrder;

public class CreateProductInOrderValidator : AbstractValidator<CreateProductInOrderCommand>
{
    public CreateProductInOrderValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.Actor).NotNull();
        RuleFor(c => c.Quantity).GreaterThan(0);
    }
}
