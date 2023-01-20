using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.Input.ProductDTO;
using Workshop.Domain.DTO.Output.ProductDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.ProductUseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public CreateProductUseCase(
        IProductRepository repository, 
        IEmployeeRepository employeeRepository
    )
    {
        _productRepository = repository;
        _employeeRepository = employeeRepository;
    }

    public GenericResult Handle(CreateProductDTO data, Guid ExecutorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("product", data.Notifications);
        }

        var user = _employeeRepository.GetByUserId(ExecutorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (!user.VerifyPermission("product:create"))
        {
            return new UnauthorizedResult("product:create");
        }

        var product = new Product(data.Name, data.Description, data.Price, user.CompanyId, data.QuantityInStock);
        _productRepository.Create(product);

        return new SuccessResult("Produto criado com sucesso!", new ProductResultDTO(product));
    }
}
