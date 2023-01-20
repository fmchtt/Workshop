using Flunt.Notifications;
using Workshop.Domain.DTO.Input.Contracts;

namespace Workshop.Domain.DTO.Input.OrderDTO;

public class CreateOrderDTO : Notifiable, IDTO
{
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }

    public void Validate()
    {
        throw new NotImplementedException();
    }
}
