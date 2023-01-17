using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.ProductDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.ProductUseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public CreateProductUseCase(IProductRepository repository, IUserRepository userRepository)
    {
        _productRepository = repository;
        _userRepository = userRepository;
    }

    public GenericResult Handle(CreateProductDTO data, Guid ExecutorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("product", data.Notifications);
        }

        var user = _userRepository.GetById(ExecutorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (!user.Employee.VerifyPermission("product:create"))
        {
            return new UnauthorizedResult("product:create");
        }

        var product = new Product(data.Name, data.Description, data.Price, user.Employee.CompanyId, data.QuantityInStock);
        _productRepository.Create(product);

        return new SuccessResult("Produto criado com sucesso!", product);
    }
}
