namespace Workshop.Application.Results.Management;

public class EmployeeResult
{
    public Guid Id { get; set; } = Guid.Empty;
    public CompanyResult Company { get; set; } = null!;
    public ResumedRoleResult Role { get; set; } = null!;
}
