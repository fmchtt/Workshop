using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Input.Contracts;

namespace Workshop.Domain.DTO.Input.ProductDTO;

public class DeleteProductDTO : Notifiable, IDTO
{
    public Guid ProductId { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
        );
    }
}
