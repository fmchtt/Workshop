using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Guid? ActiveEmployeeId { get; set; }
    public virtual Employee? Employee { get; set; } = null!;
    public virtual List<Employee> Employees { get; set; } = [];

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public static readonly User Empty = new(string.Empty, string.Empty, string.Empty) { Id = Guid.Empty };
}
