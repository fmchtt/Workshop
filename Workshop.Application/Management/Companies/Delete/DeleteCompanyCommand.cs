using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.Delete;

public class DeleteCompanyCommand : ICommand<string>
{
    public Guid CompanyId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
