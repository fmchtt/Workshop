using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Api.Controllers;

public abstract class WorkshopBaseController(IMediator mediator, IMapper mapper) : ControllerBase
{
    protected IMediator _mediator = mediator;
    protected IMapper _mapper = mapper;

    [NonAction]
    public Guid GetUserId()
    {
        var userId = User?.Identity?.Name;
        if (userId == null)
        {
            return Guid.Empty;
        }

        return Guid.Parse(userId);
    }

    [NonAction]
    protected async Task<User> GetUser()
    {
        var userRepository = HttpContext.RequestServices.GetService<IUserRepository>();
        if (userRepository == null)
        {
            throw new AuthorizationException("Usuário não encontrado!");
        }

        var userId = GetUserId();
        var user = await userRepository.GetById(userId);

        if (user == null)
        {
            throw new AuthorizationException("Usuário não encontrado!");
        }

        return user;
    }
}
