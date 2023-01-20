using Workshop.Domain.Contracts;
using Workshop.Domain.Repositories;
using Workshop.Domain.Entities;
using Workshop.Domain.Tests.Repositories;
using Workshop.Domain.Tests.Utils;
using Workshop.Domain.UseCases.UserUseCases;
using Workshop.Domain.DTO.Input.UserDTO;
using Workshop.Domain.Contracts.Results;

namespace Workshop.Domain.Tests.UseCasesTests.UserTests;

[TestClass]
public class CreateUserUseCaseTest
{
    private readonly FakeUserRepository _repository;
    private readonly FakeHasher _hasher;
    private readonly CreateUserUseCase _useCase;

    public CreateUserUseCaseTest()
    {
        _repository = new FakeUserRepository();
        _hasher = new FakeHasher();
        _useCase = new CreateUserUseCase(_repository, _hasher);
    }

    [TestMethod]
    public void Should_Return_Success()
    {
        var userDto = new CreateUserDto("USUARIO_TESTE", "USUARIO@TESTE.COM", "1234SENHA");

        var result = _useCase.Handle(userDto);

        Assert.IsTrue(result is SuccessResult);
    }

    [TestMethod]
    public void Should_Return_Failed()
    {
        var userDto = new CreateUserDto("U", "USUARIO@.COM", "1");

        var result = _useCase.Handle(userDto);

        Assert.IsTrue(result is InvalidDataResult);
    }

    [TestMethod]
    public void Should_User_Be_In_Repository()
    {
        var userDto = new CreateUserDto("USUARIO_TESTE", "USUARIO@TESTE.COM", "1234SENHA");

        var result = _useCase.Handle(userDto);

        var user = (User) result.Result;

        Assert.IsNotNull(_repository.GetById(user.Id));
    }
}
