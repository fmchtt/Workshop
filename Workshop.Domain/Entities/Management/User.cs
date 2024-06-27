using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class User : Entity
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public Guid? ActiveEmployeeId { get; set; }
    public virtual Employee? Employee { get; set; } = null!;
    public virtual List<Employee> Employees { get; set; } = [];

    public User()
    {
    }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public static readonly User Empty = new(string.Empty, string.Empty, string.Empty) { Id = Guid.Empty };
}
