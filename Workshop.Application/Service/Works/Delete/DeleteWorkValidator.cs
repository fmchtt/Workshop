using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Works.Delete;

public class DeleteWorkValidator : AbstractValidator<DeleteWorkCommand>
{
    public DeleteWorkValidator()
    {
        RuleFor(c => c.WorkId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
