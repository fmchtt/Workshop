namespace Workshop.Domain.Contracts;

public interface IRepository<T>
{
    Task<T?> GetById(Guid id);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
