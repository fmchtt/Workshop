﻿using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.CreateProductInOrder;

public class CreateProductInOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository) : IRequestHandler<CreateProductInOrderCommand, ProductInOrder>
{
    public async Task<ProductInOrder> Handle(CreateProductInOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão");
        }

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        var product = await productRepository.GetById(request.ProductId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(product, "Produto não encontrado!");

        var productInOrder = order.AddProduct(product, request.Quantity);
        await orderRepository.Update(order);
        await productRepository.Update(product);

        return productInOrder;
    }
}
