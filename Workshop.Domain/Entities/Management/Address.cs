using Workshop.Domain.Entities.Service;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Address : Entity
{
    public string Street { get; set; }
    public int Number { get; set; }
    public string Neighborhood { get; set; }
    public string Cep { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Complement { get; set; }
}
