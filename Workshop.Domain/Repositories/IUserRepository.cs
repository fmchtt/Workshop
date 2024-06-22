using Workshop.Domain.Entities.Management;
namespace Workshop.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(Guid id);
    Task<User?> GetByEmail(string email);
    Task Create(User user);
    Task Update(User user);
}

