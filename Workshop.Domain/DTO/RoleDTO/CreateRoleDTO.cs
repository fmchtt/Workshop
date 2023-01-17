﻿using Flunt.Notifications;
using Flunt.Validations;
using Workshop.Domain.DTO.Contracts;

namespace Workshop.Domain.DTO.RoleDTO;

public class CreateRoleDTO : Notifiable, IDTO
{
    public string Name { get; set; }
    public List<Guid> PermissionIdList { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Name, 6, "name", "Name deve ter no mínimo 6 caracteres")
        );
    }
}
