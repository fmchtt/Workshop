namespace Workshop.Domain.Contracts;

public interface IRepository<T> : IDisposable where T : class
{
    Task<T?> GetById(Guid id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
