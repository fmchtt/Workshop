using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class WorkInOrderRepository(WorkshopDBContext context) : BaseRepository<WorkInOrder>(context), IWorkInOrderRepository
{
    private readonly DbSet<WorkInOrder> _worksInOrder = context.Set<WorkInOrder>();

    public async Task<WorkInOrder?> GetWorkByIdAndOrderId(Guid workId, Guid orderId)
    {
        return await _worksInOrder.FirstOrDefaultAsync(w => w.WorkId == workId && w.OrderId == orderId);
    }

    public async Task<WorkInOrder?> GetWorkByOrderAndDescription(Guid orderId, string description)
    {
        return await _worksInOrder.FirstOrDefaultAsync(w => w.OrderId == orderId && w.Work.Description!.Equals(description, StringComparison.CurrentCultureIgnoreCase));
    }
}
