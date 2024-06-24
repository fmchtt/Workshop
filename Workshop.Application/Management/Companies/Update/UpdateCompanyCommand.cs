using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.Update;

public class UpdateCompanyCommand : ICommand<Company>
{
    [JsonIgnore]
    public Guid CompanyId { get; set; }
    public string? Name { get; set; }
    [JsonInclude]
    public User Actor { get; set; } = User.Empty;
}
