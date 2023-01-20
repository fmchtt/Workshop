using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Input.Contracts;

namespace Workshop.Domain.DTO.Input.UserDTO;

public class LoginDTO : Notifiable, IDTO
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public void Validate()
    {
        AddNotifications(new Contract().Requires().IsEmail(Email, "email", "Email invalido!"));
    }
}
