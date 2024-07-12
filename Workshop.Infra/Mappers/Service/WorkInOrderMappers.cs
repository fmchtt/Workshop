using AutoMapper;
using Workshop.Application.Results.Service;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Mappers.Service;

public class WorkInOrderMappers : Profile
{
    public WorkInOrderMappers()
    {
        CreateMap<WorkInOrder, WorkInOrderResult>();
    }
}
