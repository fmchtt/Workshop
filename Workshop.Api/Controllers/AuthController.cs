using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.DTO.Output.Generic;
using Workshop.Domain.Contracts;
using Workshop.Domain.DTO.Input.UserDTO;
using Workshop.Domain.DTO.Output.UserDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.UserUseCases;

namespace Workshop.Api.Controllers;

using NotificationList = IReadOnlyCollection<Notification>;

[ApiController, Route("auth")]
public class AuthController : WorkshopBaseController
{
    [HttpGet("me"), Authorize]
    public UserResultDTO Me(
        [FromServices] IUserRepository userRepository
    )
    {
        var user = userRepository.GetById(GetUserId());

        return Ok(new UserResultDTO(user));
    }

    [HttpPost("login"), AllowAnonymous]
    [ProducesResponseType(typeof(TokenDTO), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic Login(
        [FromBody] LoginDTO data,
        [FromServices] IUserRepository userRepository,
        [FromServices] IHasher hasher,
        [FromServices] ITokenService tokenService
    )
    {
        var result = new LoginUseCase(userRepository, hasher, tokenService).Handle(data);

        return ParseResult(result);
    }

    [HttpPost("register"), AllowAnonymous]
    [ProducesResponseType(typeof(UserResultDTO), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    public dynamic Register(
        [FromBody] CreateUserDto data,
        [FromServices] IUserRepository userRepository,
        [FromServices] IHasher hasher
    )
    {
        var result = new CreateUserUseCase(userRepository, hasher).Handle(data);

        return ParseResult(result);
    }
}
