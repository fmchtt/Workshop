using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.GetById;

public class GetClientByIdHandler(IClientRepository clientRepository) : IRequestHandler<GetClientByIdQuery, Client?>
{
    public async Task<Client?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await clientRepository.GetById(request.ClientId, request.Actor.Employee?.CompanyId ?? Guid.Empty);
    }
}
