using FluentValidation;

namespace Workshop.Application.Service.Works.Update;

public class UpdateWorkValidator : AbstractValidator<UpdateWorkCommand>
{
    public UpdateWorkValidator()
    {
        RuleFor(c => c.WorkId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Actor).NotNull();
    }
}
