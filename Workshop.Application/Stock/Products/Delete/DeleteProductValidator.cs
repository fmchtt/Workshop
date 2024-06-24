using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Stock.Products.Delete;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
