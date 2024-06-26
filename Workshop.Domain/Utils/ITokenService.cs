using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Utils;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
