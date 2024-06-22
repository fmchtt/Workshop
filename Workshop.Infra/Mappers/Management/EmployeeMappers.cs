using AutoMapper;
using Workshop.Application.Results.Management;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Mappers.Management;

public class EmployeeMappers : Profile
{
    public EmployeeMappers()
    {
        CreateMap<Employee, EmployeeResult>();
    }
}
