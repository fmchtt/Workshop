using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.RemoveEmployee;

public class DeleteEmployeeHandler(IEmployeeRepository employeeRepository) : IRequestHandler<DeleteEmployeeCommand, string>
{
    public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageEmployee") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var employee = await employeeRepository.GetById(request.EmployeeId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(employee, "Colaborador não encontrado!");

        if (employee.CompanyId != request.Actor.Employee.CompanyId)
        {
            throw new NotFoundException("Colaborador não encontrado!");
        }

        await employeeRepository.Delete(employee);

        return "Colaborador deletado com sucesso!";
    }
}
