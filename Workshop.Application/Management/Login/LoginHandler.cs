using MediatR;
using Workshop.Application.Results.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;
using Workshop.Domain.Utils;

namespace Workshop.Application.Management.Login;

public class LoginHandler(IUserRepository repository, ITokenService tokenService, IHasher hasher) : IRequestHandler<LoginCommand, TokenResult>
{
    public async Task<TokenResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByEmail(request.Email);
        NotFoundException.ThrowIfNull(user, "Usuário ou senha inválidos");

        var passwordValid = await hasher.Validate(user.Password, request.Password);
        if (!passwordValid)
        {
            throw new NotFoundException("Usuário ou senha inválidos");
        }

        var token = await tokenService.GenerateToken(user);
        return new TokenResult(token);
    }
}
