using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.ChangeCompany;

public class ChangeCompanyHandler(IUserRepository userRepository) : IRequestHandler<ChangeCompanyCommand, User>
{
    public async Task<User> Handle(ChangeCompanyCommand request, CancellationToken cancellationToken)
    {
        var employee = request.Actor.Employees.FirstOrDefault(e => e.CompanyId == request.CompanyId);
        if (employee == null)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        request.Actor.ActiveEmployeeId = employee.Id;
        await userRepository.Update(request.Actor);

        return request.Actor;
    }
}
