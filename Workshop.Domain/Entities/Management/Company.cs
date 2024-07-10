using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Company : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }
    public virtual User Owner { get; set; } = null!;
    public virtual List<Employee> Employees { get; set; } = [];
    public virtual List<Role> Roles { get; set; } = [];
    public virtual List<Client> Clients { get; set; } = [];
    public Guid? AddressId { get; set; }
    public virtual Address? Address { get; set; }
    public string? Cnpj { get; set; }
    public string? Logo { get; set; }

    public Company()
    {
    }

    public Company(string name, User owner, List<Employee> employees)
    {
        Name = name;
        OwnerId = owner.Id;
        Owner = owner;
        Employees = employees;
    }

    public Company(string name, User owner)
    {
        Name = name;
        OwnerId = owner.Id;
        Owner = owner;
    }

    public bool IsEmployee(User user)
    {
        return Employees.Any(x => x.User == user);
    }
}
