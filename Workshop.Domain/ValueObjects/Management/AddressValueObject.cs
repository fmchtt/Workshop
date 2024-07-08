using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.ValueObjects.Management;

public class AddressValueObject
{
    public string Street { get; set; }
    public int Number { get; set; }
    public string Neighborhood { get; set; }
    public string Cep { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Complement { get; set; }
}
