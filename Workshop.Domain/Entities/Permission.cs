namespace Workshop.Domain.Entities;

public class Permission : Entity
{
    public string Name { get; set; }

    public Permission(string name)
    {
        Name = name;
    }
}
