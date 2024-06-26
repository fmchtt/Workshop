using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Repositories.Core;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories.Core;

public class UnitOfWork(WorkshopDBContext context) : IUnitOfWork, IAsyncDisposable
{
    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}
