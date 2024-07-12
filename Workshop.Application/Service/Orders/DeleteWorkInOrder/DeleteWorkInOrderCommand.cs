using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.DeleteWork;

public class DeleteWorkInOrderCommand : ICommand<string>
{
    public Guid WorkId { get; set; }
    public Guid OrderId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
