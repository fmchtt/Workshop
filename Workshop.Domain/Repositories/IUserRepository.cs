using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
namespace Workshop.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmail(string email);
}

