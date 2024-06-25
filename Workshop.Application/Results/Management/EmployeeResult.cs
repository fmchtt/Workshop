namespace Workshop.Application.Results.Management;

public class EmployeeResult
{
    public Guid Id { get; set; } = Guid.Empty;
    public ResumedUserResult User { get; set; } = null!;
    public ResumedRoleResult Role { get; set; } = null!;
}
