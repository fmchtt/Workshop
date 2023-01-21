namespace Workshop.Domain.DTO.Input.RoleDTO;

public class DeleteRoleDTO
{
    public Guid RoleId { get; set; }

    public DeleteRoleDTO(Guid roleId)
    {
        RoleId = roleId;
    }
}
