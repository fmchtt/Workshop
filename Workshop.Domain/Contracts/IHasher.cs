namespace Workshop.Domain.Contracts;

public interface IHasher
{
    Task<string> Hash(string key);
    Task<bool> Validate(string hashedKey, string plainKey);
}
