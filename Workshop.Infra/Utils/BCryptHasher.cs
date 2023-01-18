using Workshop.Domain.Contracts;
namespace Workshop.Infra.Utils;

public class BCryptHasher : IHasher
{
    public string hash(string key)
    {
        return BCrypt.Net.BCrypt.HashPassword(key);
    }

    public bool validate(string hashedKey, string plainKey)
    {
        return BCrypt.Net.BCrypt.Verify(plainKey, hashedKey);
    }
}
