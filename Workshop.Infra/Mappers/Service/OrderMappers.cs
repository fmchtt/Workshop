using AutoMapper;
using Workshop.Application.Results.Service;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Mappers.Service;

public class OrderMappers : Profile
{
    public OrderMappers()
    {
        CreateMap<Order, OrderResult>();
    }
}
