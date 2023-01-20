using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Input.Contracts;

namespace Workshop.Domain.DTO.Input.UserDTO;

public class CreateUserDto : Notifiable, IDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public CreateUserDto(string name, string email, string password)
    {
        Name = name;
        Password = password;
        Email = email;
    }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Name, 4, "name", "Nome invalido!")
            .HasMinLen(Email, 6, "email", "Email Invalido!")
            .IsEmail(Email, "email", "Email Invalido!")
            .HasMinLen(Password, 8, "password", "A senha precisa contem no minimo 8 caracteres")
        );
    }
}
