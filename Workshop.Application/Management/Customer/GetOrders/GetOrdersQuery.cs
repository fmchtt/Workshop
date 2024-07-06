using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.ValueObjects.Management.Customer;

namespace Workshop.Application.Management.Customer.GetById;

public class GetOrdersQuery : IQuery<ICollection<Order>>
{

    public Guid ClientId { get; set; }
    public FilterGetAllByClientId? Filter { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
