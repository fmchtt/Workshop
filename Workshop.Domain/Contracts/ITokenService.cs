using Workshop.Domain.Entities;

namespace Workshop.Domain.Contracts;

public interface ITokenService
{
    public string GenerateToken(User user);
}
