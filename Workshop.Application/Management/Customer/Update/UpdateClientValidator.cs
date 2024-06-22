using FluentValidation;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.Update;

public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientValidator()
    {
        RuleFor(c => c.ClientId).NotEmpty();
        RuleFor(c => c.Actor).NotNull().NotEqual(User.Empty);
    }
}
