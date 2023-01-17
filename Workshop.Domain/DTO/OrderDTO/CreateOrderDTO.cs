using Flunt.Notifications;
using Workshop.Domain.DTO.Contracts;

namespace Workshop.Domain.DTO.OrderDTO;

public class CreateOrderDTO : Notifiable, IDTO
{
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }

    public void Validate()
    {
        throw new NotImplementedException();
    }
}
