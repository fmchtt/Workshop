using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Extensions;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class PermissionRepository(WorkshopDBContext context) : BaseRepository<Permission>(context), IPermissionRepository
{
    private readonly DbSet<Permission> _permissions = context.Set<Permission>();

    public async Task CreateOrUpdateRange(ICollection<Permission> permissions)
    {
        await _permissions.AddOrUpdateRange(permissions);
    }
}
