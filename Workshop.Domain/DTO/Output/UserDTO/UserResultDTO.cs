using Workshop.Domain.Entities;

namespace Workshop.Domain.DTO.Output.UserDTO;

public class UserResultDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public UserResultDTO(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
    }
}
