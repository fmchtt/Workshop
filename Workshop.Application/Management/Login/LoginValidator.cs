using FluentValidation;

namespace Workshop.Application.Management.Login;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).MinimumLength(4).NotEmpty();
        RuleFor(x => x.Password).MinimumLength(8).NotEmpty();
    }
}
