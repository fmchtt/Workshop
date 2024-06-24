using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.GetById;

public class GetClientByIdHandler(IClientRepository clientRepository) : IRequestHandler<GetClientByIdQuery, Client?>
{
    public async Task<Client?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) throw new AuthorizationException("Usuário sem permissão");

        var client = await clientRepository.GetById(request.ClientId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");

        return client;
    }
}
