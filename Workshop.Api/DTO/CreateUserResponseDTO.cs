using Workshop.Domain.Entities;

namespace Workshop.Api.DTO;

public class CreateUserResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public CreateUserResponseDTO(string name, string email, Guid id)
    {
        Name = name;
        Email = email;
        Id = id;
    }
}
