using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Works.Delete;

public class DeleteWorkCommand : ICommand<string>
{
    public Guid WorkId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
