using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.ValueObjects.Stock.Products;

public sealed record FilterGetAllProducts
{
    public string? Name { get; set; }
}
