using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.ValueObjects.Management.Customer;

public sealed record FilterGetAllByClientId
{
    public int? OrderNumber { get; set; }
    public bool? Complete { get; set; }
}
