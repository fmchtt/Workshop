using FluentValidation;
using Workshop.Application.Management.Companies.AddEmployee;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.CreateEmployee;

public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeValidator()
    {
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
        RuleFor(c => c.RoleId).NotEmpty();
    }
}
