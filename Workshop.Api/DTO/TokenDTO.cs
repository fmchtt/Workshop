namespace Workshop.Api.DTO;

public class TokenDTO
{
    public string Token { get; set; }

    public TokenDTO(string token)
    {
        Token = token;
    }
}
