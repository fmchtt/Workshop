using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.Update;

public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleValidator()
    {
        RuleFor(c => c.RoleId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
