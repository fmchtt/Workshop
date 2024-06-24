using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.Delete;

public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
