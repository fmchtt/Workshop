using Workshop.Domain.Contracts;
using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.Input.UserDTO;
using Workshop.Domain.DTO.Output.UserDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.UserUseCases;

public class CreateUserUseCase
{
    private readonly IUserRepository _repository;
    private readonly IHasher _hasher;

    public CreateUserUseCase(IUserRepository repository, IHasher hasher)
    {
        _repository = repository;
        _hasher = hasher;
    }

    public GenericResult Handle(CreateUserDto data)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("user", data.Notifications);
        }

        var user = _repository.GetByEmail(data.Email);
        if (user != null) {
            return new InvalidDataResult("email");
        }

        var password = _hasher.hash(data.Password);

        var newUser = new User(data.Name, data.Email, password);
        _repository.Create(newUser);

        return new SuccessResult("Usuário Adicionado com sucesso!", new UserResultDTO(newUser));
    }
}
