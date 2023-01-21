using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.Input.ProductDTO;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.ProductUseCases;

public class DeleteProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteProductUseCase(
        IProductRepository productRepository,
        IEmployeeRepository employeeRepository
    )
    {
        _productRepository = productRepository;
        _employeeRepository = employeeRepository;
    }

    public GenericResult Handle(DeleteProductDTO data, Guid ExecutorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("product", data.Notifications);
        }

        var user = _employeeRepository.GetByUserId(ExecutorId);
        if (user == null)
        {
            return new NotFoundResult("owner");
        }

        if (!user.VerifyPermission("product:delete"))
        {
            return new UnauthorizedResult("product:delete");
        }

        var product = _productRepository.GetByID(data.ProductId, user.CompanyId);
        if (product == null)
        {
            return new NotFoundResult("product");
        }

        _productRepository.Delete(product);

        return new SuccessResult("Produto deletado com sucesso!");
    }
}
