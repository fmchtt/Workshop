using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class AddressRepository(WorkshopDBContext context) : BaseRepository<Address>(context), IAddressRepository
{
}
