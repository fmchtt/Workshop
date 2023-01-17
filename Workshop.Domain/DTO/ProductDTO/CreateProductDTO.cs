using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Contracts;

namespace Workshop.Domain.DTO.ProductDTO;

public class CreateProductDTO : Notifiable, IDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
    public int QuantityInStock { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Name, 4, "name", "Nome invalido!")
       );
    }
}
