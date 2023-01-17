﻿namespace Workshop.Domain.Entities;

public class Employee : Entity
{
    public Guid UserId { get; set; }

    public User User { get; set; }

    public Guid CompanyId { get; set; }

    public Company Company { get; set; }

    public Role Role { get; set; }

    public Employee(Guid userId, Guid companyId, Role role)
    {
        UserId = userId;
        CompanyId = companyId;
        Role = role;
    }
}
