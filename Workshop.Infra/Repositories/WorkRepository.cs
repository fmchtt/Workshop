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
    public async Task<Work?> GetWorkByOrderAndDescription(Guid orderId, string description)
    {
        return await _works.FirstOrDefaultAsync(w => w.OrderId == orderId && w.Description!.Equals(description, StringComparison.CurrentCultureIgnoreCase));
    }
}
