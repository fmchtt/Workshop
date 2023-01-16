using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Contracts;

namespace Workshop.Domain.DTO.CompanyDTO;

public class AddEmployeeDTO : Notifiable, IDTO
{
    public AddEmployeeDTO(string name, string email, Guid companyId)
    {
        Name = name;
        Email = email;
        CompanyId= companyId;
    }

    public Guid CompanyId { get; set; }
    public Guid RoleId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }



    public void Validate()
    {
        AddNotifications(new Contract().Requires()
            .HasMinLen(Name, 4, "name", "Nome invalido!")
            .HasMinLen(Email, 6, "email", "Email Invalido!")
            .IsEmail(Email, "email", "Email Invalido!"));
    }
}
