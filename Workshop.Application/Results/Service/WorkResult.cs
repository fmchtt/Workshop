using Workshop.Application.Results.Stock;

namespace Workshop.Application.Results.Service;

public class WorkResult
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
