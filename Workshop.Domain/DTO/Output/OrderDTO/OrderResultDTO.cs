using Workshop.Domain.Entities;

namespace Workshop.Domain.DTO.Output.OrderDTO;

public class OrderResultDTO
{
    public Guid Id { get; set; }
    public int OrderNumber { get; set; }
    public List<ProductInOrder> Products { get; set; }
    public Decimal Total { get; set; }
    public Employee Employee { get; set; }
    public Client Client { get; set; }
    public bool Complete { get; set; }

    public OrderResultDTO(Order order)
    {
        Id = order.Id;
        OrderNumber = order.OrderNumber;
        Products = order.Products;
        Total = order.Total;
        Employee = order.Employee;
        Client = order.Client;
        Complete = order.Complete;
    }
}
