﻿using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee?> GetById(Guid id, Guid companyId);
}
