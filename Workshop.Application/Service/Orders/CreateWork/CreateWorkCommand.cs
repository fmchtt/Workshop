using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.CreateWork;

public class CreateWorkCommand : ICommand<Work>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
    public decimal Price { get; set; }
    public TimeOnly TimeToFinish { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
