using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Company : Entity
{
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public virtual User Owner { get; set; } = null!;
    public virtual List<Employee> Employees { get; set; } = [];
    public virtual List<Role> Roles { get; set; } = [];

    public Company(string name, Guid ownerId, List<Employee> employees)
    {
        Name = name;
        OwnerId = ownerId;
        Employees = employees;
    }

    public Company(string name, Guid ownerId)
    {
        Name = name;
        OwnerId = ownerId;
    }
}
