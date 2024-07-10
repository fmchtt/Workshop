using Workshop.Domain.Entities.Service;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Client : Entity
{
    public string Name { get; set; } = string.Empty;
    public virtual List<Order> Orders { get; set; } = [];
    public Guid? RepresentativeId { get; set; }
    public virtual User? Representative { get; set; }
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;
    public Guid? AddressId { get; set; }
    public virtual Address? Address { get; set; }
    public string? Cnpj { get; set; }

    public Client()
    {
    }

    public Client(string name, Company company)
    {
        Name = name;
        CompanyId = company.Id;
        Company = company;
    }

    public void AddRepresentative(User representative)
    {
        RepresentativeId = representative.Id;
        Representative = representative;
    }
}
