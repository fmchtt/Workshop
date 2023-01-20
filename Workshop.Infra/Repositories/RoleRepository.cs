using Workshop.Domain.Entities;
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

    public void Create(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();
    }

    public void Delete(Role role)
    {
        _context.Roles.Remove(role);
        _context.SaveChanges();
    }

    public Role getById(Guid roleId)
    {
        var role = _context.Roles.First(x => x.Id == roleId);

        return role;
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();
    }
}
