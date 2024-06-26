﻿using Workshop.Domain.Entities.Management;
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

    public Order()
    {
    }

    public Order(Company company, Employee employee, Client client)
    {
        Employee = employee;
        EmployeeId = employee.Id;
        Client = client;
        ClientId = client.Id;
        Company = company;
        CompanyId = company.Id;
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
            var productInOrder = new ProductInOrder(product, this, quantity);
            Products.Add(productInOrder);
            return productInOrder;
        }

        Products[index].Quantity += quantity;
        return Products[index];
    }

    public ProductInOrder UpdateProduct(Product product, int quantity)
    {
        var index = Products.FindIndex(p => p.ProductId == product.Id);
        if (Products[index].Quantity < quantity)
        {
            var quantityDelta = quantity - Products[index].Quantity;
            if (product.QuantityInStock < quantityDelta)
            {
                throw new ValidationException("Produto sem quantidade suficiente!");
            }
            product.QuantityInStock -= quantityDelta;
        } 
        else
        {
            var quantityDelta = Products[index].Quantity - quantity;
            product.QuantityInStock += quantityDelta;
        }

        Products[index].Quantity = quantity;
        return Products[index];
    }

    public void RemoveProduct(Product product)
    {
        var index = Products.FindIndex(p => p.ProductId == product.Id);
        if (index == -1)
        {
            throw new ValidationException("Produto não está na ordem de serviço");
        }

        product.QuantityInStock += Products[index].Quantity;
        Products.RemoveAt(index);
    }
}
