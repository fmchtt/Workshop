using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.ProductDTO;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.ProductUseCases;

public class DeleteProductUseCase
{
    IProductRepository _productRepository;
    IUserRepository _userRepository;

    public DeleteProductUseCase(IProductRepository productRepository, IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
    }
    public GenericResult Handle(DeleteProductDTO data, Guid UserId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("product", data.Notifications);
        }

        var product = _productRepository.GetByID(data.ProductId);
        if (product == null)
        {
            return new NotFoundResult("product");
        }

        var user = _userRepository.GetById(UserId);
        if (user == null || user.Employee.CompanyId != product.OwnerId) {
            return new NotFoundResult("owner");
        }

        _productRepository.Delete(product.Id);

        return new SuccessResult("Produto deletado com sucesso!", null);
    }
}
