using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class WorkRepository(WorkshopDBContext context) : BaseRepository<Work>(context), IWorkRepository
{
    private readonly DbSet<Work> _works = context.Set<Work>();

    public async Task<Work?> GetByDescription(string description, Guid ownerId)
    {
        return await _works.FirstOrDefaultAsync(x => x.Description!.Equals(description, StringComparison.CurrentCultureIgnoreCase) && x.OwnerId == ownerId);
    }

    public async Task<Work?> GetById(Guid id, Guid CompanyId)
    {
        return await _works.FirstOrDefaultAsync(x => x.OwnerId == CompanyId && x.Id == id);
    }

    public Task<Work> CreateAndReturn(Work work)
    {
        var newWork = _works.Add(work);
        return Task.FromResult(newWork.Entity);
    }
}
