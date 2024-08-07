﻿using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Invitations.Create;

public class CreateInvitationCommand : ICommand<Invitation>
{
    public string Email { get; set; } = string.Empty;
    public Guid? CompanyId { get; set; }
    public Guid? ClientId { get; set; }

    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
