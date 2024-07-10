using MediatR;
using Workshop.Application.Results.Management;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;
using Workshop.Domain.Utils;

namespace Workshop.Application.Management.Register;

public class RegisterHandler(IUserRepository repository, IHasher hasher, ITokenService tokenService, 
    IInvitationRepository invitationRepository, IClientRepository clientRepository) 
    : IRequestHandler<RegisterCommand, TokenResult>
{
    public async Task<TokenResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await repository.GetByEmail(request.Email);
        if (foundUser != null)
        {
            throw new ValidationException("Email inválido, tente utilizar outro email!");
        }

        var password = await hasher.Hash(request.Password);
        var user = new User(request.Name, request.Email, password);
        await repository.Create(user);
        var token = await tokenService.GenerateToken(user);

        await VerifyExistingInvitesAndAdd(invitationRepository, clientRepository, request, user);

        return new TokenResult(token);
    }

    private static async Task VerifyExistingInvitesAndAdd(IInvitationRepository invitationRepository, IClientRepository clientRepository, RegisterCommand request, User user)
    {
        var invites = await invitationRepository.GetByEmail(request.Email);

        if (invites is null || !invites.Any())
        {
            return;
        }

        invites = invites.Where(x => x.ClientId is not null && x.ExpirationDate > DateTime.Now).ToList();

        foreach (var invite in invites)
        {
            invite.InvalidateInvite();
            var client = await clientRepository.GetById((Guid)invite.ClientId);
            NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");

            client.AddRepresentative(user);

            await clientRepository.Update(client);
            await invitationRepository.Update(invite);
        }
    }
}
