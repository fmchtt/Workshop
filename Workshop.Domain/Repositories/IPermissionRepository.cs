using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IPermissionRepository
{
    List<Permission> GetAll();
    Permission GetByResourceName(string resourceName);
    Permission GetById(Guid id);
}
