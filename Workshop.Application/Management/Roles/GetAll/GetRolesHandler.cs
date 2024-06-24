using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Roles.GetRoles;

public class GetRolesHandler(IRoleRepository roleRepository) : IRequestHandler<GetRolesQuery, ICollection<Role>>
{
    public async Task<ICollection<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) return [];

        return await roleRepository.GetAll(request.Actor.Employee.CompanyId);
    }
}
