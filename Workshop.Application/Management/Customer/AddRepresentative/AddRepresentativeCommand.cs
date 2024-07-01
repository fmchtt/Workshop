using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Customer.AddRepresentative;

public class AddRepresentativeCommand : ICommand<Client>
{
    public string Email { get; set; } = string.Empty;
    public Guid ClientId { get; set; }

    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}

