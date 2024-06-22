namespace Workshop.Domain.Exceptions;

public record ValidationError(string Property, string Message);

public class ValidationException : Exception
{
    public List<ValidationError>? Errors { get; set; }

    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(string message, List<ValidationError> errors) : base(message)
    {
        Errors = errors;
    }

    public ValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
