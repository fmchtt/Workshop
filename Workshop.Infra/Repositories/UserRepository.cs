using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class UserRepository(WorkshopDBContext context) : BaseRepository<User>(context), IUserRepository
{
    private readonly DbSet<User> _users = context.Set<User>();

    public async Task<User?> GetByEmail(string email)
    {
        return await _users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
