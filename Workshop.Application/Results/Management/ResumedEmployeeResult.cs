namespace Workshop.Application.Results.Management;

public class EmployeeWithCompanyResult
{
    public Guid Id { get; set; } = Guid.Empty;
    public CompanyResult Company { get; set; } = null!;
    public ResumedUserResult User { get; set; } = null!;
    public RoleResult Role { get; set; } = null!;
}
