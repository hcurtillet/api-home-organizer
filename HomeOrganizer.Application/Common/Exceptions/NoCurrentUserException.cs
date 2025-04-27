namespace HomeOrganizer.Application.Common.Exceptions;

public class NoCurrentUserException: Exception
{
    public NoCurrentUserException() : base("No current user found.")
    {
    }

    public NoCurrentUserException(string message) : base(message)
    {
    }

    public NoCurrentUserException(string message, Exception innerException) : base(message, innerException)
    {
    }
}