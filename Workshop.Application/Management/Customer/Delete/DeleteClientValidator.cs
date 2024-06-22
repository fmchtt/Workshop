using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.Delete;

public class DeleteClientValidator : AbstractValidator<DeleteClientCommand>
{
    public DeleteClientValidator()
    {
        RuleFor(c => c.ClientId).NotEmpty();
        RuleFor(c => c.Actor).NotEmpty().NotEqual(User.Empty);
    }
}
