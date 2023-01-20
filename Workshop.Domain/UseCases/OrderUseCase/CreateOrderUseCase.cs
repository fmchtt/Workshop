using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.Input.OrderDTO;
using Workshop.Domain.DTO.Output.OrderDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.OrderUseCase;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public CreateOrderUseCase(
        IOrderRepository orderRepository, 
        IEmployeeRepository employeeRepository
    )
    {
        _orderRepository = orderRepository;
        _employeeRepository = employeeRepository;
    }

    public GenericResult Handle(CreateOrderDTO data, Guid executorId)
    {
        var user = _employeeRepository.GetByUserId(executorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (!user.VerifyPermission("order:create"))
        {
            return new UnauthorizedResult("order:create");
        }

        var order = new Order(_orderRepository.GetMaxOrderNumber(user.CompanyId) + 1, 0, user.Id);
        _orderRepository.Create(order);

        return new SuccessResult("Pedido criado com sucesso!", new OrderResultDTO(order));
    }
}
