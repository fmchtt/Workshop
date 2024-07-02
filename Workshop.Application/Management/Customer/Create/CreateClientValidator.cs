using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.Create;

public class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(4);
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
