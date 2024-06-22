using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.Update;

public class UpdateClientCommand : ICommand<Client>
{
    public Guid ClientId { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
