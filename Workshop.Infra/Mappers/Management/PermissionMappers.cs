using AutoMapper;
using Workshop.Application.Results.Management;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Mappers.Management;

public class PermissionMappers : Profile
{
    public PermissionMappers()
    {
        CreateMap<Permission, PermissionResult>();
    }
}
