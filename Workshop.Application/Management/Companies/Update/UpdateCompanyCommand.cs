using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Management;

namespace Workshop.Application.Management.Companies.Update;

public class UpdateCompanyCommand : ICommand<Company>
{
    [JsonIgnore]
    public Guid CompanyId { get; set; }
    public string? Name { get; set; }
    public AddressValueObject? Address { get; set; }
    public string? Cnpj { get; set; }
    public string? Logo { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
