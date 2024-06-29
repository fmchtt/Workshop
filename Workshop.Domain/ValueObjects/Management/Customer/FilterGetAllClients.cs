using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.ValueObjects.Management.Customer;

public sealed record FilterGetAllClients
{
    public string? Name { get; set; }
}
