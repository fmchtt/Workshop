using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;
public class Invitation : Entity
{
    public string Email { get; set; }
    public DateTime ExpirationDate { get; set; }
    public Guid? CompanyId { get; set; }
    public virtual Company? Company { get; set; }
    public Guid? ClientId { get; set; }
    public virtual Client? Client { get; set; }

    public Invitation(string email, DateTime expirationDate)
    {
        Email = email;
        ExpirationDate = expirationDate;
    }

    public void InviteRepresentative(Guid? clientId)
    {
        ClientId = clientId;
    }

    public void InviteEmployee(Guid? companyId)
    {
        CompanyId = companyId;
    }

    public void InvalidateInvite()
    {
        ExpirationDate = DateTime.Now;
    }
}
