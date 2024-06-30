using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.ValueObjects.Management.Companies;

public sealed record GetAllEmployeesFilter
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}
