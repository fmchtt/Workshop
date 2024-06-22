using FluentValidation;

namespace Workshop.Application.Stock.Products.Create;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(c => c.Actor).NotNull();
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        RuleFor(c => c.Price).GreaterThan(0);
        RuleFor(c => c.Quantity).GreaterThanOrEqualTo(0);
    }
}
