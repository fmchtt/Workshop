using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Input.Contracts;

namespace Workshop.Domain.DTO.Input.CompanyDTO;

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
