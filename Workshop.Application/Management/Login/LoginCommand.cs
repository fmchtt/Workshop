using Workshop.Application.Results.Management;
using Workshop.Application.Shared;

namespace Workshop.Application.Management.Login;

public class LoginCommand : ICommand<TokenResult>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
