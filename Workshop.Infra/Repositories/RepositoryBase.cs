using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Shared;
using Workshop.Infra.Extensions;

namespace Workshop.Infra.Repositories;

public abstract class RepositoryBase<TContext, T> : IRepository<T>
    where TContext : DbContext
    where T : class
{
    protected readonly TContext Context;
    protected readonly DbSet<T> DbSet;
    protected RepositoryBase(TContext context) 
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task Create(T entity)
    {
        try
        {
            var result = await DbSet.AddAsync(entity);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível criar: {typeof(T).Assembly.FullName}, entidade: {entity}, {ex.Message}");
            throw;
        }
    }

    public Task Delete(T entity)
    {
        try
        {
            var result = DbSet.Remove(entity);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível remover: {typeof(T).Assembly.FullName}, entidade: {entity}, {ex.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        Context.Dispose();
    }

    public async Task<T?> GetById(Guid id)
    {
        try
        {
            return await DbSet.FindAsync(id);
        }catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível pesquisar: {typeof(T).Assembly.FullName}, chave: {id}, {ex.Message}");
            throw;
        }
    }

    public Task Update(T entity)
    {
        try
        {
            var result = DbSet.Update(entity);

            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível atualizar: {typeof(T).Assembly.FullName}, entidade:  {entity}, {ex.Message}");
            throw;
        }
    }

    public Task UpdateManyToMany<TKey>(IEnumerable<T> currentItems, IEnumerable<T> newItems, Func<T, TKey> getKey)
    {
        try
        {
            EntityExtensions.TryUpdateManyToMany(Context, currentItems, newItems, getKey);

            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível atualizar: {typeof(T).Assembly.FullName}, {ex.Message}");
            throw;
        }
    }
}
