using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Api.Adapters;
using Workshop.Api.DTO;
using Workshop.Domain.Contracts;
using Workshop.Domain.DTO.UserDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.UserUseCases;

namespace Workshop.Api.Controllers;

[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login(
        [FromBody] LoginDTO data,
        [FromServices] IUserRepository userRepository,
        [FromServices] IHasher hasher,
        [FromServices] ITokenService tokenService
    )
    {
        var result = new LoginUseCase(userRepository, hasher, tokenService).Handle(data);

        return ResultAdapter<TokenDTO>.Parse(result);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public IActionResult Register(
        [FromBody] CreateUserDto data,
        [FromServices] IUserRepository userRepository,
        [FromServices] IHasher hasher
    )
    {
        var result = new CreateUserUseCase(userRepository, hasher).Handle(data);

        return ResultAdapter<TokenDTO>.Parse(result);
    }
}
