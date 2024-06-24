using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.DeletePermission;

public class DeletePermissionValidator : AbstractValidator<DeletePermissionCommand>
{
    public DeletePermissionValidator()
    {
        RuleFor(c => c.PermissionId).NotEmpty();
        RuleFor(c => c.RoleId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
