using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Stock.Products.Update;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
        RuleFor(c => c.QuantityInStock).GreaterThanOrEqualTo(0);
        RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
    }
}
