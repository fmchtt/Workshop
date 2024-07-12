using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Works.Create;

public class CreateWorkCommand : ICommand<Work>
{
    public string? Description { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
