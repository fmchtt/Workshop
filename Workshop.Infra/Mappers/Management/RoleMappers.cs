using AutoMapper;
using Workshop.Application.Results.Management;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Mappers.Management;

public class RoleMappers : Profile
{
    public RoleMappers()
    {
        CreateMap<Role, RoleResult>();
        CreateMap<Role, ResumedRoleResult>();
    }
}
