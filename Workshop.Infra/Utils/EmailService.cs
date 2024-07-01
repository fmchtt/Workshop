using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Contracts;

namespace Workshop.Infra.Utils;

public class EmailService(IFluentEmail fluentEmail) : IEmailService
{
    public async Task Send(string sendTo, string subject, string body)
    {
        await fluentEmail
            .To(sendTo)
            .Subject(subject)
            .Body(body)
            .SendAsync();
    }
}
