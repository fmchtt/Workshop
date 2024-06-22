using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.Delete;

public class DeleteClientCommand : ICommand<string>
{
    public Guid ClientId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
