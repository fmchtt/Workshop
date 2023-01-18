using Flunt.Notifications;
using Workshop.Domain.DTO.Contracts;

namespace Workshop.Domain.DTO.RoleDTO;

public class AddPermissionDTO : Notifiable, IDTO
{
    public Guid PermissionId { get; set; }
    public Guid RoleId { get; set; }

    public void Validate()
    {
        throw new NotImplementedException();
    }
}
