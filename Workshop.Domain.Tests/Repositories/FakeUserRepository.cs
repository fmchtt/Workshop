using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.Tests.Repositories;

public class FakeUserRepository : IUserRepository
{
    List<User> _users = new List<User>();

    public void Create(User user)
    {
        _users.Add(user);
    }

    public User GetByEmail(string email)
    {
        foreach (var user in _users)
        {
            if (user.Email == email)
            {
                return user;
            }
        }

        return null;
    }

    public User GetById(Guid id)
    {
        foreach (var user in _users)
        {
            if (user.Id == id)
            {
                return user;
            }
        }

        return null;
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}
