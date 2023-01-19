using Workshop.Domain.Contracts;
using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.UserDTO;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.UserUseCases;

public class LoginUseCase
{
    private readonly IUserRepository _repository;
    private readonly IHasher _hasher;
    private readonly ITokenService _tokenService;

    public LoginUseCase(IUserRepository repository, IHasher hasher, ITokenService tokenService)
    {
        _repository = repository;
        _hasher = hasher;
        _tokenService = tokenService;
    }

    public GenericResult Handle(LoginDTO data)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("user", data.Notifications);
        }

        var user = _repository.GetByEmail(data.Email);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        var isPasswordValid = _hasher.validate(user.Password, data.Password);
        if (!isPasswordValid) {
            return new NotFoundResult("user");
        }

        var token = _tokenService.GenerateToken(user);

        return new SuccessResult("Usuario autenticado com sucesso!", new { Token = token });
    }
}
