namespace Workshop.Domain.Entities;

public class Order : Entity
{
    public int OrderNumber { get; set; }
    public List<ProductInOrder> Products { get; set; }
    public Decimal Total { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public bool Complete { get; set; }

    public Order(int orderNumber, int total, Guid employeeId)
    {
        OrderNumber = orderNumber;
        Total = total;
        EmployeeId = employeeId;
    }

    public void CalculateTotalPrice()
    {
        var total = Products.Sum(p => p.Product.Price * p.Quantity);
        Total = total;
    }
}
