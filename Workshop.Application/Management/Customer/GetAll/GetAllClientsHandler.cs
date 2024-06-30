using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.GetAll;

public class GetAllClientsHandler(IClientRepository clientRepository) : IRequestHandler<GetAllClientsQuery, ICollection<Client>>
{
    public async Task<ICollection<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) return [];

        if(request.Filter is null) return await clientRepository.GetAll(request.Actor.Employee.CompanyId);

        return await clientRepository.GetAll(request.Actor.Employee.CompanyId, request.Filter);
    }
}
