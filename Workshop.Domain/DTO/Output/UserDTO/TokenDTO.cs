namespace Workshop.Domain.DTO.Output.UserDTO;

public class TokenDTO
{
    public string Token { get; set; }

    public TokenDTO(string token)
    {
        Token = token;
    }
}
