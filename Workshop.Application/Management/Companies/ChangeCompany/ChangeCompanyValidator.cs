using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.ChangeCompany;

public class ChangeCompanyValidator : AbstractValidator<ChangeCompanyCommand>
{
    public ChangeCompanyValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
