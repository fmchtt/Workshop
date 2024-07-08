using AutoMapper;
using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.Update;

public class UpdateClientHandler(IClientRepository clientRepository, IAddressRepository addressRepository, IMapper mapper) : IRequestHandler<UpdateClientCommand, Client>
{
    public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageClient") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var client = await clientRepository.GetById(request.ClientId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");

        if (request.Name != null)
        {
            client.Name = request.Name;
        }

        if (request.Address is not null)
        {
            client.Address = mapper.Map<Address>(request.Address);
            await addressRepository.Create(client.Address);
            client.AddressId = client.Address.Id;
        }

        if (request.Cnpj is not null)
        {
            client.Cnpj = request.Cnpj;
        }

        await clientRepository.Update(client);

        return client;
    }
}
