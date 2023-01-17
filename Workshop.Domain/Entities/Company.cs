namespace Workshop.Domain.Entities;

public class Company : Entity
{
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
    public List<Employee> Employees { get; set; }

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
