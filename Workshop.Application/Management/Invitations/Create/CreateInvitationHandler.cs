using MediatR;
using Workshop.Application.Management.Customer.Create;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Invitations.Create;

public class CreateInvitationHandler(IInvitationRepository invitationRepository) : IRequestHandler<CreateInvitationCommand, Invitation>
{
    public async Task<Invitation> Handle(CreateInvitationCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageClient") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var invite = new Invitation(request.Email, DateTime.Now.AddDays(7));

        if (request.ClientId is not null)
        {
            invite.InviteRepresentative(request.ClientId);
        }
        else if (request.CompanyId is not null)
        {
            invite.InviteEmployee(request.CompanyId);
        }

        await invitationRepository.Create(invite);

        return invite;
    }
}
