namespace Workshop.Domain.Utils;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransaction(CancellationToken cancellationToken = default);
    Task Commit(CancellationToken cancellationToken = default);
    Task Rollback(CancellationToken cancellationToken = default);
}
