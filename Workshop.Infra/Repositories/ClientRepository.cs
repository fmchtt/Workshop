using MediatR;
using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Domain.ValueObjects.Management.Customer;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class ClientRepository(WorkshopDBContext context) : BaseRepository<Client>(context), IClientRepository
{
    private readonly DbSet<Client> _clients = context.Set<Client>();

    public async Task<ICollection<Client>> GetAll(Guid companyId)
    {
        return await _clients.Where(x => x.CompanyId == companyId).ToListAsync();
    }

    public async Task<ICollection<Client>> GetAll(Guid companyId, FilterGetAllClients filters)
    {
        var clients = _clients.Where(x => x.CompanyId == companyId);

        if (filters.Name is not null)
        {
            clients = clients.Where(e => e.Name.Contains(filters.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        return await clients.ToListAsync();
    }

    public async Task<Client?> GetById(Guid id, Guid companyId)
    {
        return await _clients.FirstOrDefaultAsync(x => x.CompanyId == companyId && x.Id == id);
    }
}
