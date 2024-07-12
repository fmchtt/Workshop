using Workshop.Application.Results.Stock;

namespace Workshop.Application.Results.Service;

public class WorkResult
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public TimeOnly TimeToFinish { get; set; }
    public string? Description { get; set; }
}
