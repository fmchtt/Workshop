using Workshop.Domain.Entities;
namespace Workshop.Domain.Repositories;

public interface IUserRepository
{
    User GetById(Guid id);
    User GetByEmail(string email);
    void Create(User user);
    void Update(User user);
}

