using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.CreateWork;

public class CreateWorkInOrderCommand : ICommand<WorkInOrder>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
    public Guid WorkId { get; set; }
    public decimal Price { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateFinish { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
