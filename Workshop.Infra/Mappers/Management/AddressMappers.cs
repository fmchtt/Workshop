using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Management;

namespace Workshop.Infra.Mappers.Management;

public class AddressMappers : Profile
{
    public AddressMappers()
    {
        CreateMap<AddressValueObject, Address>();
    }
}
