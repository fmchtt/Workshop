using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Api.Adapters;
using Workshop.Domain.Contracts;
using Workshop.Domain.DTO.Input.UserDTO;
using Workshop.Domain.DTO.Output.UserDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.UserUseCases;

namespace Workshop.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpGet("me")]
    [Authorize]
    public IActionResult Me(
        [FromServices] IUserRepository userRepository
    )
    {
        var user = userRepository.GetById(Guid.Parse(User.Identity.Name));

        return new OkObjectResult(new UserResultDTO(user));
    }

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

        return ResultAdapter.Parse(result);
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

        return ResultAdapter.Parse(result);
    }
}
