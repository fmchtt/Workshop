using Workshop.Application.Results.Management;

namespace Workshop.Application.Results.Service;

public class OrderResult
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public ICollection<ProductInOrderResult> Products { get; set; } = [];
    public EmployeeResult Employee { get; set; } = null!;
    public ClientResult Client { get; set; } = null!;
    public bool Complete { get; set; }
}
