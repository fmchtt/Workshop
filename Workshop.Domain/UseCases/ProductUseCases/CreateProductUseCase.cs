using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.ProductDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.ProductUseCases;

public class CreateProductUseCase
{
    IProductRepository _repository;

    public CreateProductUseCase(IProductRepository repository) { 
        _repository = repository;
    }

    public GenericResult Handle(CreateProductDTO data, Guid OwnerId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("product", data.Notifications);
        }

        var product = new Product(data.Name, data.Description, data.Price, OwnerId);
        _repository.Create(product);

        return new SuccessResult("Produto criado com sucesso!", product);
    }
}
