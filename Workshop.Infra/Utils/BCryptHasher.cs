using Workshop.Domain.Contracts;
namespace Workshop.Infra.Utils;

public class BCryptHasher : IHasher
{
    public Task<string> Hash(string key)
    {
        return Task.FromResult(BCrypt.Net.BCrypt.HashPassword(key));
    }

    public Task<bool> Validate(string hashedKey, string plainKey)
    {
        return Task.FromResult(BCrypt.Net.BCrypt.Verify(plainKey, hashedKey));
    }
}
