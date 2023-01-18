using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Workshop.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WorkshopDBContext _context;

    public UserRepository(WorkshopDBContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User GetByEmail(string email)
    {
        var user = _context.Users
            .Include(u => u.Employee.Permissions)
            .FirstOrDefault(u => u.Email == email);

        return user;
    }

    public User GetById(Guid id)
    {
        var user = _context.Users
            .Include(u => u.Employee.Permissions)
            .FirstOrDefault(u => u.Id == id);

        return user;
    }

    public void Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
