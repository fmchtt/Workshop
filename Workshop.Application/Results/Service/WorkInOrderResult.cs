using Workshop.Application.Results.Stock;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Results.Service;

public class WorkInOrderResult
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateFinish { get; set; }
    public WorkResult Work { get; set; } = null!;
}
