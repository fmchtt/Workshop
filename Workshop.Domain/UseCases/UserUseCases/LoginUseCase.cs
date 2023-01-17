using Workshop.Domain.Contracts;
using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.UserDTO;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.UserUseCases;

public class LoginUseCase
{
    IUserRepository _repository;
    IHasher _hasher;

    public LoginUseCase(IUserRepository repository, IHasher hasher)
    {
        _repository = repository;
        _hasher = hasher;
    }

    public GenericResult handle(LoginDTO data)
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

        return new SuccessResult("Usuario autenticado com sucesso!", user);
    }
}
