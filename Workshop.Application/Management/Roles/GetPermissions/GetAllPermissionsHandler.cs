using MediatR;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.GetPermissions;

public class GetAllPermissionsHandler : IRequestHandler<GetAllPermissionsQuery, Dictionary<string, List<string>>>
{
    public Task<Dictionary<string, List<string>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Permission.List);
    }
}
