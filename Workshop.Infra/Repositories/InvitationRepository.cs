using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class InvitationRepository(WorkshopDBContext context) : BaseRepository<Invitation>(context), IInvitationRepository
{
    private readonly DbSet<Invitation> _invitations = context.Set<Invitation>();
    public async Task<ICollection<Invitation>?> GetByEmail(string email)
    {
        return await _invitations.Where(i => i.Email == email).ToListAsync();
    }
}
