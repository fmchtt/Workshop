using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Results;
using Workshop.Application.Results.Service;
using Workshop.Application.Service.Orders.CompleteOrder;
using Workshop.Application.Service.Orders.Create;
using Workshop.Application.Service.Orders.CreateProductInOrder;
using Workshop.Application.Service.Orders.Delete;
using Workshop.Application.Service.Orders.DeleteProductInOrder;
using Workshop.Application.Service.Orders.GetAll;
using Workshop.Application.Service.Orders.GetById;
using Workshop.Application.Service.Orders.Update;
using Workshop.Application.Service.Orders.UpdateProductInOrder;
using Workshop.Domain.ValueObjects.Service.Orders;

namespace Workshop.Api.Controllers;

[ApiController, Route("orders"), Authorize]
public class OrderController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet("{id}")]
    public async Task<OrderResult> GetOrder(
        [FromRoute] Guid id
    )
    {
        var query = new GetOrderByIdQuery { Actor = await GetUser(), OrderId = id };
        return _mapper.Map<OrderResult>(await _mediator.Send(query));
    }

    [HttpGet]
    public async Task<ICollection<OrderResult>> GetOrders([FromQuery] FilterGetAllOrders? filters)
    {
        var query = new GetAllOrdersQuery { Actor = await GetUser(), Filters = filters };
        return _mapper.Map<ICollection<OrderResult>>(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<OrderResult> CreateOrder(
        [FromBody] CreateOrderCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<OrderResult>(await _mediator.Send(command));
    }

    [HttpPatch("{id}")]
    public async Task<OrderResult> UpdateOrder(
        [FromRoute] Guid id,
        [FromBody] UpdateOrderCommand command
    )
    {
        command.OrderId = id;
        command.Actor = await GetUser();
        return _mapper.Map<OrderResult>(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<MessageResult> DeleteOrder(
        [FromRoute] Guid id
    )
    {
        var command = new DeleteOrderCommand { OrderId = id, Actor = await GetUser() };
        return new MessageResult(await _mediator.Send(command));
    }

    [HttpPost("{id}/complete")]
    public async Task<OrderResult> CompleteOrder(
        [FromRoute] Guid id
    )
    {
        var command = new CompleteOrderCommand { Actor = await GetUser(), OrderId = id };
        return _mapper.Map<OrderResult>(await _mediator.Send(command));
    }

    [HttpPost("{id}/product")]
    public async Task<ProductInOrderResult> AddProduct(
        [FromRoute] Guid id,
        [FromBody] CreateProductInOrderCommand command
    )
    {
        command.Actor = await GetUser();
        command.OrderId = id;
        return _mapper.Map<ProductInOrderResult>(await _mediator.Send(command));
    }

    [HttpPatch("{id}/product/{productId}")]
    public async Task<ProductInOrderResult> RemoveProduct(
        [FromRoute] Guid id,
        [FromRoute] Guid productId,
        [FromBody] UpdateProductInOrderCommand command
    )
    {
        command.Actor = await GetUser();
        command.OrderId = id;
        command.ProductId = productId;

        return _mapper.Map<ProductInOrderResult>(await _mediator.Send(command));
    }

    [HttpDelete("{id}/product/{productId}")]
    public async Task<MessageResult> RemoveProduct(
        [FromRoute] Guid id,
        [FromRoute] Guid productId
    )
    {
        var command = new DeleteProductInOrderCommand { Actor = await GetUser(), OrderId = id, ProductId = productId };
        return new MessageResult(await _mediator.Send(command));
    }
}
