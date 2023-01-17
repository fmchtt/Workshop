using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.ProductDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.Contracts;

namespace Workshop.Domain.UseCases.ProductUseCases;

public class CreateProductUseCase : IUseCase<CreateProductDTO>
{
    IProductRepository _repository;

    public CreateProductUseCase(IProductRepository repository) { 
        _repository = repository;
    }

    public GenericResult handle(CreateProductDTO data)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("product", data.Notifications);
        }

        var product = new Product(data.Name, data.Description, data.Price, data.OwnerId);
        _repository.Create(product);

        return new SuccessResult("Produto criado com sucesso!", product);
    }
}
