using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Application.Results.Management;

public class EmployeeWithCompanyResult
{
    public Guid Id { get; set; } = Guid.Empty;
    public CompanyResult Company { get; set; } = null!;
    public ResumedUserResult User { get; set; } = null!;
    public ResumedRoleResult Role { get; set; } = null!;
}
