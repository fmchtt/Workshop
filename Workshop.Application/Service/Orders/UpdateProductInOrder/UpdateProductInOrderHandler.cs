using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.UpdateProductInOrder;

public class UpdateProductInOrderHandler(IOrderRepository orderRepository, IProductInOrderRepository productInOrderRepository, IProductRepository productRepository) : IRequestHandler<UpdateProductInOrderCommand, ProductInOrder>
{
    public async Task<ProductInOrder> Handle(UpdateProductInOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        var productInOrder = order.Products.Find(p => p.ProductId == request.ProductId);
        NotFoundException.ThrowIfNull(productInOrder, "Produto não encontrado na ordem de serviço!");

        var product = productInOrder.Product;
        productInOrder = order.UpdateProduct(product, request.Quantity);
        await productInOrderRepository.Update(productInOrder);
        await productRepository.Update(product);

        return productInOrder;
    }
}
