﻿using Workshop.Domain.Entities.Service;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Client : Entity
{
    public string Name { get; set; } = string.Empty;
    public virtual List<Order> Orders { get; set; } = [];
    public Guid? RepresentativeId { get; set; }
    public virtual User? Representative { get; set; }
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;

    public Client()
    {
    }

    public Client(string name, Company company)
    {
        Name = name;
        CompanyId = company.Id;
        Company = company;
    }

    public void AddRepresentative(Guid representativeId)
    {
        RepresentativeId = representativeId;
    }
}
