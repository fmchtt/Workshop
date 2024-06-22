using Workshop.Domain.Entities.Service;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Client : Entity
{
    public string Name { get; set; }
    public virtual List<Order> Orders { get; set; } = [];
    public Guid? RepresentativeId { get; set; }
    public virtual User? Representative { get; set; }
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;

    public Client(string name, Guid companyId)
    {
        Name = name;
        CompanyId = companyId;
    }
}
