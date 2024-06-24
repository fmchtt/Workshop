using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.RemoveEmployee;

public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeValidator()
    {
        RuleFor(c => c.EmployeeId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
