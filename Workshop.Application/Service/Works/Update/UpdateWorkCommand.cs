using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Works.Update;

public class UpdateWorkCommand : ICommand<Work>
{
    public Guid WorkId { get; set; }
    public string? Description { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
