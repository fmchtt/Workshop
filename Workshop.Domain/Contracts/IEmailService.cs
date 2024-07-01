using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.Contracts;

public interface IEmailService
{
    Task Send(string sendTo, string subject, string body);
}
