using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.Create;

public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(4);
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
