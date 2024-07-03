using FluentEmail.Core;
using Workshop.Domain.Contracts;

namespace Workshop.Infra.Utils;

public class EmailService(IFluentEmail fluentEmail) : IEmailService
{
    public async Task Send(string sendTo, string subject, string body)
    {
#if DEBUG
        Console.WriteLine("================== Email enviado ==================");
        Console.WriteLine($"Para: {sendTo}");
        Console.WriteLine($"Titulo: {subject}");
        Console.WriteLine($"Texto: {body}");
        Console.WriteLine("===================================================");
        return;
#else
        await fluentEmail
            .To(sendTo)
            .Subject(subject)
            .Body(body)
            .SendAsync();
#endif

    }
}
