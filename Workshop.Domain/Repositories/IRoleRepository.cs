﻿using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IRoleRepository
{
    Role getById(Guid roleId);
    void Create(Role role);
    void Delete(Guid id);
}