namespace Workshop.Application.Results.Management;

public class ActualUserResult
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public EmployeeWithCompanyResult Working { get; set; } = null!;
}
