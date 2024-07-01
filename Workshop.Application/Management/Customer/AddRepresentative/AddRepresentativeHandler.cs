using MediatR;
using Workshop.Application.Management.Customer.AddRepresentative;
using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.Create;

public class AddRepresentativeHandler(IClientRepository clientRepository, IUserRepository userRepository, IEmailService emailService) 
    : IRequestHandler<AddRepresentativeCommand, Client>
{
    public async Task<Client> Handle(AddRepresentativeCommand request, CancellationToken cancellationToken)
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
            await emailService.Send(request.Email, "Workshop - Crie sua conta para ser o representante da sua empresa no nosso sistema", "Enviar a url botao sei lá");
            return client;
        }

        client.AddRepresentative(user.Id);

        await clientRepository.Update(client);

        return client;
    }
}
