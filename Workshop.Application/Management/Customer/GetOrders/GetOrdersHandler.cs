using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Customer.GetById;

public class GetOrdersHandler(IClientRepository clientRepository, IOrderRepository orderRepository) : IRequestHandler<GetOrdersQuery, ICollection<Order>>
{

    public async Task<ICollection<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var client = await clientRepository.GetById(request.ClientId);
        NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");

        if (client.RepresentativeId != request.Actor.Id) throw new AuthorizationException("Usuário sem permissão");

        if (request.Filter is null) return await orderRepository.GetAllByClientId(request.ClientId);

        var orders = await orderRepository.GetAllByClientId(request.ClientId, request.Filter);

        return orders;
    }
}
