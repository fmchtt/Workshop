using Workshop.Domain.Contracts;
using Workshop.Domain.Entities;

namespace Workshop.Tests.Utils;

public class FakeTokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        return user.Id.ToString();
    }
}
