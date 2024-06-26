using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.ChangeCompany;

public class ChangeCompanyCommand : ICommand<User>
{
    public Guid CompanyId { get; set; }
    public User Actor { get; set; } = User.Empty;
}
