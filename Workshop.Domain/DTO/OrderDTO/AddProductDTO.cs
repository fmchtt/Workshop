using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Contracts;

namespace Workshop.Domain.DTO.OrderDTO;

public class AddProductDTO : Notifiable, IDTO
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid OrderId { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .IsGreaterThan(Quantity, 0, "quantity", "Deve ser adicionado mais de 0 produtos!")
        );
    }
}
