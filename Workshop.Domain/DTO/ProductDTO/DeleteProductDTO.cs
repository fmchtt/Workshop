using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Contracts;

namespace Workshop.Domain.DTO.ProductDTO;

public class DeleteProductDTO: Notifiable, IDTO
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
