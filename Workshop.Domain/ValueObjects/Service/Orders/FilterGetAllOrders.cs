using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.ValueObjects.Service.Orders;

public sealed record FilterGetAllOrders
{
    public int? OrderNumber { get; set; }
    public string? ClientId { get; set; }
    public Guid? EmployeeId { get; set; }
    public bool? Complete { get; set; }
}
