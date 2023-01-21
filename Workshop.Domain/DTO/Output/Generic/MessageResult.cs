namespace Workshop.Domain.DTO.Output.Generic;

public class MessageResult
{
    public string Message { get; set; }

    public MessageResult(string message) { 
        Message = message;
    }
}
