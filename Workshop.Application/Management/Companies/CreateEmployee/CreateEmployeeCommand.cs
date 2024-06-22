﻿using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.AddEmployee;

public class CreateEmployeeCommand : ICommand<Employee>
{
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid RoleId { get; set; } = Guid.Empty;
}
