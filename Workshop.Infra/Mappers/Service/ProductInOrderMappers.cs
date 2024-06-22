using AutoMapper;
using Workshop.Application.Results.Service;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Mappers.Service;

public class ProductInOrderMappers : Profile
{
    public ProductInOrderMappers()
    {
        CreateMap<ProductInOrder, ProductInOrderResult>();
    }
}
