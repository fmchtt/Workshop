using Workshop.Domain.Contracts;
using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.UserDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.UserUseCases;

public class CreateUserUseCase
{
    IUserRepository _repository;
    IHasher _hasher;

    public CreateUserUseCase(IUserRepository repository, IHasher hasher)
    {
        _repository = repository;
        _hasher = hasher;
    }

    public GenericResult handle(CreateUserDto data)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("user", data.Notifications);
        }

        var password = _hasher.hash(data.Password);

        var newUser = new User(data.Name, data.Email, password);
        _repository.Create(newUser);

        return new SuccessResult("Usuário Adicionado com sucesso!", newUser);
    }
}
