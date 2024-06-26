using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class RoleRepository(WorkshopDBContext context) : RepositoryBase<WorkshopDBContext, Role>(context), IRoleRepository
{
    private readonly DbSet<Role> _roles = context.Set<Role>();

    public async Task<ICollection<Role>> GetAll(Guid companyId)
    {
        return await _roles.Where(x => x.CompanyId == companyId).ToListAsync();
    }

    public async Task<Role?> GetById(Guid roleId, Guid companyId)
    {
        return await _roles.FirstOrDefaultAsync(x => x.Id == roleId && x.CompanyId == companyId);
    }

}
