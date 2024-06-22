using AutoMapper;
using Workshop.Application.Results.Management;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Mappers.Management;

public class UserMappers : Profile
{
    public UserMappers()
    {
        CreateMap<User, ActualUserResult>().ForMember(dest => dest.Working, opts => opts.MapFrom(src => src.Employee));
    }
}
