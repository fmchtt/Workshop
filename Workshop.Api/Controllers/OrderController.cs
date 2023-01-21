using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.DTO.Input.OrderDTO;
using Workshop.Domain.DTO.Output.Generic;
using Workshop.Domain.DTO.Output.OrderDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.OrderUseCase;

namespace Workshop.Api.Controllers;

using NotificationList = IReadOnlyCollection<Notification>;

[ApiController, Route("orders")]
public class OrderController : WorkshopBaseController
{
    [HttpGet("{id}"), Authorize]
    [ProducesResponseType(typeof(OrderResultDTO), 200)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic GetOrder(
        [FromServices] IOrderRepository orderRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        string id
    )
    {
        var employee = employeeRepository.GetByUserId(GetUserId());
        var order = orderRepository.GetById(Guid.Parse(id), employee.CompanyId);
        if (order == null)
        {
            return NotFound("Pedido não encontrado!");
        }

        return Ok(new OrderResultDTO(order));
    }

    [HttpGet, Authorize]
    public IEnumerable<OrderResultDTO> GetProducts(
        [FromServices] IOrderRepository orderRepository,
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var employee = employeeRepository.GetByUserId(GetUserId());
        var orderList = orderRepository.GetAll(employee.CompanyId);

        var orders = new List<OrderResultDTO>();
        foreach (var item in orderList)
        {
            orders.Add(new OrderResultDTO(item));
        }

        return Ok(orders);
    }

    [HttpPost, Authorize]
    [ProducesResponseType(typeof(OrderResultDTO), 200)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic CreateOrder(
        [FromBody] CreateOrderDTO data,
        [FromServices] IOrderRepository orderRepository,
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var result = new CreateOrderUseCase(orderRepository, employeeRepository).Handle(data, GetUserId());

        return ParseResult(result);
    }

    [HttpPost("add"), Authorize]
    [ProducesResponseType(typeof(MessageResult), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic AddProduct(
        [FromBody] AddProductDTO data,
        [FromServices] IOrderRepository orderRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        [FromServices] IProductRepository productRepository
    )
    {
        var result = new AddProductUseCase(productRepository, orderRepository, employeeRepository).Handle(data, GetUserId());

        return ParseResult(result);
    }
}
