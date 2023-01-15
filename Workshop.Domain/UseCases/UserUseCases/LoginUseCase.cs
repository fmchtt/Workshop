using Workshop.Domain.Contracts;
using Workshop.Domain.DTO.Results;
using Workshop.Domain.DTO.UserDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.Contracts;

namespace Workshop.Domain.UseCases.UserUseCases;

public class LoginUseCase : IUseCase<LoginDTO>
{
    IUserRepository _repository;
    IHasher _hasher;

    public LoginUseCase(IUserRepository repository, IHasher hasher)
    {
        _repository = repository;
        _hasher = hasher;
    }

    public GenericResultDTO handle(LoginDTO data)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResultDTO("user", data.Notifications);
        }

        var user = _repository.GetByEmail(data.Email);
        if (user == null)
        {
            return new NotFoundResultDTO("user");
        }

        var isPasswordValid = _hasher.validate(user.Password, data.Password);
        if (!isPasswordValid) {
            return new NotFoundResultDTO("user");
        }

        return new SuccessResultDTO("Usuario autenticado com sucesso!", user);
    }
}
