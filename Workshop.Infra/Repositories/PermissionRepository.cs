using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class PermissionRepository(WorkshopDBContext context) : RepositoryBase<WorkshopDBContext, Permission>(context), IPermissionRepository
{
    private readonly DbSet<Permission> _permissions = context.Set<Permission>();

    public async Task CreateOrUpdateRange(ICollection<Permission> permissions)
    {
        var existentPermissionIds = await _permissions.Where(p => permissions.Contains(p)).Select(p => p.Id).ToListAsync();
        var existentPermissions = permissions.Where(x => existentPermissionIds.Contains(x.Id)).ToList();
        var newPermissions = permissions.Where(x => !existentPermissionIds.Contains(x.Id)).ToList();

        _permissions.AddRange(newPermissions);
        _permissions.UpdateRange(existentPermissions);
    }
}
