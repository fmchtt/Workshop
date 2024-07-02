using MediatR;
using Workshop.Application.Management.Customer.AddRepresentative;
using Workshop.Application.Management.Invitations.Create;
using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.Create;

public class AddRepresentativeHandler(IClientRepository clientRepository, IUserRepository userRepository, 
    IEmailService emailService, IMediator mediator, IInvitationRepository invitationRepository) 
    : IRequestHandler<AddRepresentativeCommand, string>
{
    public async Task<string> Handle(AddRepresentativeCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageClient") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var client = await clientRepository.GetById(request.ClientId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");

        var user = await userRepository.GetByEmail(request.Email);
        if (user is null)
        {
            var invite = new Invitation(request.Email, DateTime.Now.AddDays(7));

            invite.InviteRepresentative(request.ClientId);

            await invitationRepository.Create(invite);

            await emailService.Send(request.Email, "Workshop - Crie sua conta para ser o representante da sua empresa no nosso sistema", "Enviar a url botao sei lá");
            return "Convite enviado com sucesso";
        }

        client.AddRepresentative(user.Id);

        await clientRepository.Update(client);

        return "Representante vinculado com sucesso.";
    }
}
