using FluentValidation;
using Workshop.Application.Management.Customer.Create;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Invitations.Create;

public class CreateInvitationValidator : AbstractValidator<CreateInvitationCommand>
{
    public CreateInvitationValidator()
    {
        RuleFor(c => c.Email).NotNull().EmailAddress();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
