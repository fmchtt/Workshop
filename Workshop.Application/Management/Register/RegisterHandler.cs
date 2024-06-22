using MediatR;
using Workshop.Application.Results.Management;
using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Register;

public class RegisterHandler(IUserRepository repository, IHasher hasher, ITokenService tokenService) : IRequestHandler<RegisterCommand, TokenResult>
{
    public async Task<TokenResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await repository.GetByEmail(request.Email);
        if (foundUser != null)
        {
            throw new ValidationException("Email inválido, tente utilizar outro email!");
        }

        var password = await hasher.Hash(request.Password);
        var user = new User(request.Name, request.Email, password);
        await repository.Create(user);
        var token = await tokenService.GenerateToken(user);
        return new TokenResult(token);
    }
}
