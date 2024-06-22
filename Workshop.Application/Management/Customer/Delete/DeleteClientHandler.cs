using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.Delete;

public class DeleteClientHandler(IClientRepository clientRepository) : IRequestHandler<DeleteClientCommand, string>
{
    public async Task<string> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageClient") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var client = await clientRepository.GetById(request.ClientId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");
        await clientRepository.Delete(client);

        return "Cliente deletado com sucesso!";
    }
}
