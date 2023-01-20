using Workshop.Domain.Entities;

namespace Workshop.Domain.DTO.Output.RoleDTO;

public class RoleResultDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Permission> Permissions { get; set; }

    public RoleResultDTO(Role role)
    {
        Id = role.Id;
        Name = role.Name;
        Permissions = role.Permissions;
    }
}
