using Flunt.Notifications;
using Workshop.Domain.DTO.Input.Contracts;

namespace Workshop.Domain.DTO.Input.RoleDTO;

public class AddPermissionDTO : Notifiable, IDTO
{
    public Guid PermissionId { get; set; }
    public Guid RoleId { get; set; }

    public void Validate()
    {
        throw new NotImplementedException();
    }
}
