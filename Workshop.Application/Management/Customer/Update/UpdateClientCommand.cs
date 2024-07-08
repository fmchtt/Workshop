using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Management;

namespace Workshop.Application.Management.Customer.Update;

public class UpdateClientCommand : ICommand<Client>
{
    public Guid ClientId { get; set; }
    public string? Name { get; set; }
    public AddressValueObject? Address { get; set; }
    public string? Cnpj { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
