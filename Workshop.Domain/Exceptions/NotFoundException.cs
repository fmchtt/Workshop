using System.Diagnostics.CodeAnalysis;

namespace Workshop.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public static void ThrowIfNull([NotNull] object? argument, string message)
    {
        if (argument == null) throw new NotFoundException(message);
    }
}
