using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.Delete;

public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleValidator()
    {
        RuleFor(c => c.RoleId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
