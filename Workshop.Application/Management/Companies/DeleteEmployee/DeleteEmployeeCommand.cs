using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.RemoveEmployee;

public class DeleteEmployeeCommand : ICommand<string>
{
    public Guid EmployeeId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
