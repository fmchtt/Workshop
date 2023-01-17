using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IPermissionRepository
{
    Permission GetByResourceName(string resourceName);
    Permission GetById(Guid id);
}
