namespace Workshop.Domain.Entities;

public class Role : Entity
{
    public string Name { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    public List<Permission> Permissions { get; set; }

    public Role(string name, Guid companyId)
    {
        Name = name;
        CompanyId = companyId;
    }

    public Role(string name, Guid companyId, List<Permission> permissions)
    {
        Name = name;
        CompanyId = companyId;
        Permissions = permissions;
    }

}
