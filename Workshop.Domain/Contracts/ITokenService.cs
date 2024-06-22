using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Contracts;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
