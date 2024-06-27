using Microsoft.EntityFrameworkCore.Storage;
using Workshop.Domain.Utils;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Utils;

public class UnitOfWork(WorkshopDBContext context) : IUnitOfWork, IAsyncDisposable
{
    private IDbContextTransaction? _transaction;

    public async Task BeginTransaction(CancellationToken cancellationToken = default)
    {
        _transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task Commit(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
        if (_transaction != null) await _transaction.CommitAsync(cancellationToken);
    }

    public async Task Rollback(CancellationToken cancellationToken = default)
    {
        if (_transaction != null) await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}
