using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.OrderDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.OrderUseCase;

public class AddProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;

    public AddProductUseCase(IProductRepository productRepository, IOrderRepository orderRepository, IUserRepository userRepository) {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public GenericResult Handle(AddProductDTO data, Guid executorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("product", data.Notifications);
        }

        var user = _userRepository.GetById(executorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (!user.Employee.VerifyPermission("order:create"))
        {
            return new UnauthorizedResult("order:create");
        }

        var product = _productRepository.GetByID(data.ProductId);
        if (product == null)
        {
            return new NotFoundResult("product");
        }

        if (product.Stock < data.Quantity)
        {
            return new InvalidDataResult("A quantidade de produtos é maior que o estoque!");
        }

        var order = _orderRepository.GetById(data.OrderId);
        if (order == null)
        {
            return new NotFoundResult("order");
        }

        product.Stock -= data.Quantity;
        _productRepository.Update(product);

        var productInOrder = new ProductInOrder(data.ProductId, data.OrderId, data.Quantity);

        order.Products.Add(productInOrder);
        order.CalculateTotalPrice();
        _orderRepository.Update(order);

        return new SuccessResult("Produto adicionado com sucesso!");
    }
}
