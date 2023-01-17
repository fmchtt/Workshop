namespace Workshop.Domain.Contracts.Results;

public class UnauthorizedResult : GenericResult
{
    public UnauthorizedResult(string permissionCode) : base(permissionCode)
    {
        Message = $"Sem autorização para executar a ação: {permissionCode}!";
    }
}
