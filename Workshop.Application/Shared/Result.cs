namespace Workshop.Application.Shared;

public enum ResultType
{
    SUCCESS,
    NOTFOUND,
    UNAUTHORIZED,
    INVALID
}

public class Result<T>
{
    public Result(ResultType type, string? message, T? obj)
    {
        Type = type;
        Message = message;
        Object = obj;
    }

    public Result(ResultType type, string? message)
    {
        Type = type;
        Message = message;
    }

    public ResultType Type { get; set; }
    public string? Message { get; set; }
    public T? Object { get; set; }

    public static Result<T> Success(T obj)
    {
        return new(ResultType.SUCCESS, null, obj);
    }

    public static Result<T> NotFound(string message)
    {
        return new(ResultType.NOTFOUND, message);
    }

    public static Result<T> Unauthorized(string message)
    {
        return new(ResultType.UNAUTHORIZED, message);
    }

    public static Result<T> Invalid(string message)
    {
        return new(ResultType.INVALID, message);
    }
}
