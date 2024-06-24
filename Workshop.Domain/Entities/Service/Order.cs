using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Shared;
using Workshop.Domain.Exceptions;

namespace Workshop.Domain.Entities.Service;

public class Order : Entity
{
    public int OrderNumber { get; set; }
    public virtual List<ProductInOrder> Products { get; set; } = [];
    public bool Complete { get; set; }
    public Guid EmployeeId { get; set; }
    public virtual Employee Employee { get; set; } = null!;
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;
    public Guid ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;

    public decimal Total { get { return Products.Sum(p => p.Product.Price * p.Quantity); } }

    public Order(Guid companyId, Guid employeeId, Guid clientId)
    {
        EmployeeId = employeeId;
        ClientId = clientId;
        CompanyId = companyId;
    }

    public ProductInOrder AddProduct(Product product, int quantity)
    {
        if (product.QuantityInStock < quantity)
        {
            throw new ValidationException("Produto sem quantidade suficiente!");
        }
        product.QuantityInStock -= quantity;

        var index = Products.FindIndex(p => p.ProductId == product.Id);
        if (index == -1)
        {
            var productInOrder = new ProductInOrder(product.Id, Id, quantity);
            Products.Add(productInOrder);
            return productInOrder;
        }

        Products[index].Quantity += quantity;
        return Products[index];
    }

    public void RemoveProduct(Product product, int quantity)
    {
        var index = Products.FindIndex(p => p.ProductId == product.Id);
        if (index == -1)
        {
            throw new ValidationException("Produto não está na ordem de serviço");
        }


        if (Products[index].Quantity < quantity)
        {
            throw new ValidationException("Produto na ordem de serviço sem quantidade suficiente!");
        }

        product.QuantityInStock += quantity;
        Products[index].Quantity -= quantity;
        if (Products[index].Quantity <= 0)
        {
            Products.RemoveAt(index);
        }
    }
}
