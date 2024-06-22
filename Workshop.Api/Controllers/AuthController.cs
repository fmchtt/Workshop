using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Management.Login;
using Workshop.Application.Management.Register;
using Workshop.Application.Results.Management;

namespace Workshop.Api.Controllers;

[ApiController, Route("auth")]
public class AuthController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet("me"), Authorize]
    public async Task<ActualUserResult> Me()
    {
        return _mapper.Map<ActualUserResult>(await GetUser());
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<TokenResult> Login([FromBody] LoginCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPost("register"), AllowAnonymous]
    public async Task<TokenResult> Register(
        [FromBody] RegisterCommand command
    )
    {
        return await _mediator.Send(command);
    }
}
