using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class ClientRepository(WorkshopDBContext context) : IClientRepository
{
    public async Task<ICollection<Client>> GetAll(Guid companyId)
    {
        return await context.Clients.Where(x => x.CompanyId == companyId).ToListAsync();
    }

    public async Task<Client?> GetById(Guid id, Guid companyId)
    {
        return await context.Clients.FirstOrDefaultAsync(x => x.CompanyId == companyId && x.Id == id);
    }

    public async Task<Client?> GetById(Guid id)
    {
        return await context.Clients.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(Client entity)
    {
        context.Clients.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(Client entity)
    {
        context.Clients.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Client entity)
    {
        context.Clients.Remove(entity);
        await context.SaveChangesAsync();
    }
}
