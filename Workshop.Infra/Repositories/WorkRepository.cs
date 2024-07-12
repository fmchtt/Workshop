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
}
