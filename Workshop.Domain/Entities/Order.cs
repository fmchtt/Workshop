namespace Workshop.Domain.Entities;

public class Order : Entity
{
    public int OrderNumber { get; set; }

    public List<Product> Products { get; set; }

    public int Total { get; set; }

    public int EmployeeId { get; set; }

    public Employee Employee { get; set; }

    public Order(int orderNumber, List<Product> products, int total, int employeeId)
    {
        OrderNumber = orderNumber;
        Products = products;
        Total = total;
        EmployeeId = employeeId;
    }
}
