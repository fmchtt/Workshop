using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly WorkshopDBContext _context;

    public RoleRepository(WorkshopDBContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Role>> GetAll(Guid companyId)
    {
        return await _context.Roles.Where(x => x.CompanyId == companyId).ToListAsync();
    }

    public async Task<Role?> GetById(Guid roleId, Guid companyId)
    {
        return await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId && x.CompanyId == companyId);
    }

    public async Task<Role?> GetById(Guid id)
    {
        return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Role role)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Role role)
    {
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }
}
