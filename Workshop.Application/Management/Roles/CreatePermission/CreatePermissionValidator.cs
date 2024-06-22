using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.CreatePermission;

public class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionValidator()
    {
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
        RuleFor(c => c.RoleId).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Value).NotEmpty();
    }
}
