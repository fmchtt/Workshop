namespace Workshop.Domain.Entities;

public class Permission : Entity
{
    public string Name { get; set; }
    public string ResourceCode { get; set; }

    public Permission(string name, string resourceCode)
    {
        Name = name;
        ResourceCode = resourceCode;
    }
}
