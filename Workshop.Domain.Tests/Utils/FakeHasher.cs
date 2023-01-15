using Workshop.Domain.Contracts;

namespace Workshop.Domain.Tests.Utils;

public class FakeHasher : IHasher
{
    public string hash(string key)
    {
        return $"HASHED_{key}_KEY_FAKE";
    }

    public bool validate(string hashedKey, string plainKey)
    {
        var pass = hash(plainKey);

        return pass == hashedKey;
    }
}
