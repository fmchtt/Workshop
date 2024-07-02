using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.Create;

public class CreateClientHandler(IClientRepository clientRepository) : IRequestHandler<CreateClientCommand, Client>
{
    public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageClient") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var client = new Client(request.Name, request.Actor.Employee.Company);
        await clientRepository.Create(client);

        return client;
    }
}
