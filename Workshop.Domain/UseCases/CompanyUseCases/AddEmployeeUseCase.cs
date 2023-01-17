﻿using Workshop.Domain.DTO.CompanyDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.Entities;
using Workshop.Domain.Contracts.Results;

namespace Workshop.Domain.UseCases.CompanyUseCases;

public class AddEmployeeUseCase
{
    IUserRepository _userRepository;
    ICompanyRepository _companyRepository;
    IRoleRepository _roleRepository;

    public AddEmployeeUseCase(IUserRepository userRepository, ICompanyRepository companyRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _roleRepository = roleRepository;
    }

    public GenericResult Handle(AddEmployeeDTO data, Guid ExecutorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("employee", data.Notifications);
        }

        var executor = _userRepository.GetById(ExecutorId);
        if (executor == null)
        {
            return new NotFoundResult("user");
        }

        if (executor.Employee.VerifyPermission("employee:create"))
        {
            return new UnauthorizedResult("employee:create");
        }

        var company = _companyRepository.GetById(executor.Employee.CompanyId);
        if (company == null)
        {
            return new NotFoundResult("company");
        }

        var user = _userRepository.GetByEmail(data.Email);
        if (user == null)
        {
            user = new User(data.Name, data.Email, new Guid().ToString());
            _userRepository.Create(user);
        }

        if (company.Employees.Find(x => x.UserId == user.Id) != null)
        {
            return new InvalidDataResult("user", new());
        }

        var role = _roleRepository.getById(data.RoleId);
        if (role == null)
        {
            return new NotFoundResult("role");
        }
        
        if (role.CompanyId != company.Id)
        {
            return new InvalidDataResult("role", new());
        }

        var newEmployee = new Employee(user.Id, company.Id, role);
        company.Employees.Add(newEmployee);

        return new SuccessResult("Funcionario adicionado com sucesso!", newEmployee);
    }
}
