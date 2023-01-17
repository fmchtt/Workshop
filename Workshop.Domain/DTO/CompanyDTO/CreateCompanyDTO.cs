using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Contracts;
namespace Workshop.Domain.DTO.CompanyDTO;

public class CreateCompanyDTO : Notifiable, IDTO
{
    public string Name { get; set; }

    public CreateCompanyDTO(string name)
    {
        Name = name;
    }

    public void Validate()
    {
        AddNotifications(new Contract().Requires().HasMinLen(Name, 4, "name", "O Nome da empresa deve conter no mínimo 4 caracteres"));
    }
}
