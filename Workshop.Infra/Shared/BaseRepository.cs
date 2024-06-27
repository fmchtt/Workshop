using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Shared;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Shared;

public abstract class BaseRepository<T>(WorkshopDBContext context) : IRepository<T> where T : Entity
{
    protected readonly DbSet<T> DbSet = context.Set<T>();

    public async Task<T?> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task Create(T entity)
    {
        var result = await DbSet.AddAsync(entity);
    }

    public Task Update(T entity)
    {
        DbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task Delete(T entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
