using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IInvitationRepository : IRepository<Invitation>
{
    Task<IEnumerable<Invitation>?> GetByEmail(string email);
}
