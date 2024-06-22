using AutoMapper;
using Workshop.Application.Results.Stock;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Mappers.Stock;

public class ProductMappers : Profile
{
    public ProductMappers()
    {
        CreateMap<Product, ProductResult>();
    }
}
