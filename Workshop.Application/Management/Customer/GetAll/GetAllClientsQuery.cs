using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Management.Customer;

namespace Workshop.Application.Management.Customer.GetAll;

public class GetAllClientsQuery : IQuery<ICollection<Client>>
{
    [JsonIgnore]
    public User Actor { get; set; } = null!;
    public FilterGetAllClients? Filter { get; set; }
}
