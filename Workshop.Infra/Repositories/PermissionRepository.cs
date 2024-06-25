using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class PermissionRepository(WorkshopDBContext context) : IPermissionRepository
{
    public async Task<Permission?> GetById(Guid id)
    {
        return await context.Permissions.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Create(Permission entity)
    {
        context.Permissions.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(Permission entity)
    {
        context.Permissions.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Permission entity)
    {
        context.Permissions.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task CreateOrUpdateRange(ICollection<Permission> permissions)
    {
        var existentPermissionIds = await context.Permissions.Where(p => permissions.Contains(p)).Select(p => p.Id).ToListAsync();
        var existentPermissions = permissions.Where(x => existentPermissionIds.Contains(x.Id)).ToList();
        var newPermissions = permissions.Where(x => !existentPermissionIds.Contains(x.Id)).ToList();

        context.Permissions.AddRange(newPermissions);
        context.Permissions.UpdateRange(existentPermissions);

        await context.SaveChangesAsync();
    }
}
