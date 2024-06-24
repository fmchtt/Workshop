﻿using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.GetAll;

public class GetAllCompaniesQuery : IQuery<ICollection<Company>>
{
    public User Actor { get; set; } = User.Empty;
}
