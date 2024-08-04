using FluentValidation;

namespace Workshop.Application.Service.Works.Create;

public class CreateWorkValidator : AbstractValidator<CreateWorkCommand>
{
    public CreateWorkValidator()
    {
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Actor).NotNull();
    }
}
