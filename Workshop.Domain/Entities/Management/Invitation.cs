using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;
public class Invitation : Entity
{
    public Guid? ClientId { get; set; }
    public string Email { get; set; }
    public Guid? CompanyId { get; set; }
    public DateTime ExpirationDate { get; set; }

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
