using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.OrderDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.OrderUseCase;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;

    public CreateOrderUseCase(IOrderRepository orderRepository, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
    }

    public GenericResult Handle(CreateOrderDTO data, Guid executorId)
    {
        var user = _userRepository.GetById(executorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (!user.Employee.VerifyPermission("order:create"))
        {
            return new UnauthorizedResult("order:create");
        }

        var order = new Order(_orderRepository.GetMaxOrderNumber(user.Employee.CompanyId) + 1, 0, user.Employee.Id);
        _orderRepository.Create(order);

        return new SuccessResult("Pedido criado com sucesso!", order);
    }
}
