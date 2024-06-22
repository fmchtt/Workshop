using FluentValidation;

namespace Workshop.Application.Management.Register;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Name).MinimumLength(4).NotEmpty();
        RuleFor(x => x.Email).MinimumLength(4).NotEmpty();
        RuleFor(x => x.Password).MinimumLength(8).NotEmpty();
    }
}
