using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Management.Customer.AddRepresentative;
using Workshop.Application.Management.Customer.Create;
using Workshop.Application.Management.Customer.Delete;
using Workshop.Application.Management.Customer.GetAll;
using Workshop.Application.Management.Customer.GetById;
using Workshop.Application.Management.Customer.Update;
using Workshop.Application.Results;
using Workshop.Application.Results.Management;
using Workshop.Application.Results.Service;
using Workshop.Domain.ValueObjects.Management.Customer;

namespace Workshop.Api.Controllers;

[ApiController, Route("clients"), Authorize]
public class ClientController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet]
    public async Task<ICollection<ClientResult>> List([FromQuery] FilterGetAllClients? filter)
    {
        var query = new GetAllClientsQuery { Actor = await GetUser(), Filter = filter };
        return _mapper.Map<ICollection<ClientResult>>(await _mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<ClientResult> GetById([FromRoute] Guid id)
    {
        var query = new GetClientByIdQuery { Actor = await GetUser(), ClientId = id };
        return _mapper.Map<ClientResult>(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<ClientResult> Create([FromBody] CreateClientCommand command)
    {
        command.Actor = await GetUser();
        return _mapper.Map<ClientResult>(await _mediator.Send(command));
    }

    [HttpPatch("{id}")]
    public async Task<ClientResult> Update([FromRoute] Guid id, [FromBody] UpdateClientCommand command)
    {
        command.Actor = await GetUser();
        command.ClientId = id;
        return _mapper.Map<ClientResult>(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<MessageResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteClientCommand { Actor = await GetUser(), ClientId = id };
        return new MessageResult(await _mediator.Send(command));
    }

    [HttpPost("representative")]
    public async Task<MessageResult> AddRepresentative([FromBody] AddRepresentativeCommand command)
    {
        command.Actor = await GetUser();
        return new MessageResult(await _mediator.Send(command));
    }

    [HttpGet("orders/{clientId}")]
    public async Task<ICollection<OrderResult>> GetOrders([FromRoute] Guid clientId, [FromQuery] FilterGetAllByClientId? filter)
    {
        var query = new GetOrdersQuery { Actor = await GetUser(), ClientId = clientId, Filter = filter };
        return _mapper.Map<ICollection<OrderResult>>(await _mediator.Send(query));
    }
}
