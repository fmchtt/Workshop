using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.AddRepresentative;

public class AddRepresentativeValidator : AbstractValidator<AddRepresentativeCommand>
{
    public AddRepresentativeValidator()
    {
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.ClientId).NotNull();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
