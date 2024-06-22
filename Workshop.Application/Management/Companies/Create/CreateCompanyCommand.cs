using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.Create;

public class CreateCompanyCommand : ICommand<Company>
{
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
    public string Name { get; set; } = string.Empty;
}
