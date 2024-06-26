using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Infra.Extensions;

public static class EntityExtensions
{
    public static IQueryable<T> GetPage<T>(this IQueryable<T> query, int page, int pageSize)
    {
        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }
    public static void TryUpdateManyToMany<T, TKey>(this DbContext db, IEnumerable<T> currentItems,
           IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class
    {
        db.Set<T>().RemoveRange(currentItems.Except(newItems, getKey));
        db.Set<T>().AddRange(newItems.Except(currentItems, getKey));
    }

    public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> items, IEnumerable<T> otherItems, Func<T, TKey> getKeyFunc)
    {
        return items
            .GroupJoin(otherItems, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
            .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, tempItem) => new { t, tempItem })
            .Where(t => ReferenceEquals(null, t.tempItem) || t.tempItem.Equals(default(T)))
            .Select(t => t.t.item);
    }
}
