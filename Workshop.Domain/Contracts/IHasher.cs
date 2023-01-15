namespace Workshop.Domain.Contracts;

public interface IHasher
{
    string hash(string key);
    bool validate(string hashedKey, string plainKey);
}
