namespace Workshop.Domain.Utils;

public interface IHasher
{
    Task<string> Hash(string key);
    Task<bool> Validate(string hashedKey, string plainKey);
}
