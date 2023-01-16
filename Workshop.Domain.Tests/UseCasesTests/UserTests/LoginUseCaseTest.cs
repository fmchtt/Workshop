using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.UserDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Tests.Repositories;
using Workshop.Domain.Tests.Utils;
using Workshop.Domain.UseCases.UserUseCases;

namespace Workshop.Domain.Tests.UseCasesTests.UserTests;

[TestClass]
public class LoginUseCaseTest
{
    private readonly FakeUserRepository _repository;
    private readonly FakeHasher _hasher;
    private readonly LoginUseCase _useCase;

    public LoginUseCaseTest()
    {
        _repository = new FakeUserRepository();
        _hasher = new FakeHasher();
        _useCase = new LoginUseCase(_repository, _hasher);
    }

    [TestMethod]
    public void Should_Return_Success()
    {
        var password = _hasher.hash("PASSWORD1234");
        var user = new User("TESTE_USER", "TESTE@TESTE.COM", password);
        _repository.Create(user);

        var dto = new LoginDTO("TESTE@TESTE.COM", "PASSWORD1234");

        var result = _useCase.handle(dto);

        Assert.IsTrue(result is SuccessResult);
    }

    [TestMethod]
    public void Should_Return_Invalid()
    {
        var dto = new LoginDTO("TESTE@.COM", "123");

        var result = _useCase.handle(dto);

        Assert.IsTrue(result is InvalidDataResult);
    }


    [TestMethod]
    public void Should_Return_Not_Found()
    {
        var password = _hasher.hash("PASSWORD12345");
        var user = new User("TESTE_USER", "TESTE@TESTE.COM", password);
        _repository.Create(user);

        var dto = new LoginDTO("TESTE@TESTE.COM", password);

        var result = _useCase.handle(dto);

        Assert.IsTrue(result is NotFoundResult);
    }
}
