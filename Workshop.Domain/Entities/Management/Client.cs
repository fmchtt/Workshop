using Workshop.Domain.Entities.Service;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Client : Entity
{
    public string Name { get; set; }
    public virtual List<Order> Orders { get; set; } = [];
    public Guid? RepresentativeId { get; set; }
    public virtual User? Representative { get; set; }

    public Client(string name)
    {
        Name = name;
    }
}
