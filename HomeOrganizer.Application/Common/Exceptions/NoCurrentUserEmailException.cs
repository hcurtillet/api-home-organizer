namespace HomeOrganizer.Application.Common.Exceptions;

public class NoCurrentUserEmailException: Exception
{
    public NoCurrentUserEmailException() : base("No current user email found.")
    {
    }

    public NoCurrentUserEmailException(string message) : base(message)
    {
    }

    public NoCurrentUserEmailException(string message, Exception innerException) : base(message, innerException)
    {
    }
}