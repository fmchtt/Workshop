using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.Create;

public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(4);
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
