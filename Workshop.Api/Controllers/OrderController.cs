using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Results.Service;
using Workshop.Application.Service.Orders.Create;
using Workshop.Application.Service.Orders.CreateProductInOrder;
using Workshop.Application.Service.Orders.GetAll;
using Workshop.Application.Service.Orders.GetById;

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
    public async Task<ICollection<OrderResult>> GetProducts()
    {
        var query = new GetAllOrdersQuery { Actor = await GetUser() };
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

    [HttpPost("product")]
    public async Task<ProductInOrderResult> AddProduct(
        [FromBody] CreateProductInOrderCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<ProductInOrderResult>(await _mediator.Send(command));
    }
}
