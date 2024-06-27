using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Infra.Extensions;

public static class EntityExtensions
{
    public static IQueryable<T> GetPage<T>(this IQueryable<T> query, int page, int pageSize)
    {
        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }

    public static async Task AddOrRemove<T>(this DbSet<T> dbSet, IEnumerable<T> currentItems, Expression<Func<T, bool>> findKey) where T : Entity
    {
        var items = await dbSet.Where(findKey).ToListAsync();
        var newItems = currentItems.Where(i => !items.Contains(i)).ToList();
        var removeItems = items.Where(i => !currentItems.Contains(i)).ToList();

        dbSet.RemoveRange(removeItems);
        dbSet.AddRange(newItems);
    }

    public static async Task AddOrUpdateRange<T>(this DbSet<T> dbSet, IEnumerable<T> currentItems) where T : Entity
    {
        var itemsIds = await dbSet.Where(i => currentItems.Contains(i)).Select(x => x.Id).ToListAsync();
        var newItems = currentItems.Where(i => !itemsIds.Contains(i.Id)).ToList();
        var updateItems = currentItems.Where(i => itemsIds.Contains(i.Id)).ToList();

        dbSet.UpdateRange(updateItems);
        dbSet.AddRange(newItems);
    }
}
