using Workshop.Application.Results.Management;
using Workshop.Application.Shared;

namespace Workshop.Application.Management.Register;

public class RegisterCommand : ICommand<TokenResult>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
