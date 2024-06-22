namespace Workshop.Application.Results.Management;

public class CompanyResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid OwnerId { get; set; } = Guid.Empty;
}
