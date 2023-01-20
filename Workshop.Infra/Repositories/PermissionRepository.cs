using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly WorkshopDBContext _context;

    public PermissionRepository(WorkshopDBContext context)
    {
        _context = context;
    }

    public Permission GetById(Guid id)
    {
        var permission = _context.Permissions.First(x => x.Id == id);

        return permission;
    }

    public Permission GetByResourceName(string resourceName)
    {
        var permission = _context.Permissions.First(x => x.ResourceCode == resourceName);

        return permission;
    }
}
