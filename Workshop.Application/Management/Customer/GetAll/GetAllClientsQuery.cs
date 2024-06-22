using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.GetAll;

public class GetAllClientsQuery : IQuery<ICollection<Client>>
{
    [JsonIgnore]
    public User Actor { get; set; } = null!;
}
