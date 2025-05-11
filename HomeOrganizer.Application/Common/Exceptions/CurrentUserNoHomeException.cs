namespace HomeOrganizer.Application.Common.Exceptions;

public class CurrentUserNoHomeException: Exception
{
    public Guid HomeId { get; }
    public Guid UserId { get; }
    public CurrentUserNoHomeException() : base("Current user has no home.")
    {
    }

    public CurrentUserNoHomeException(string message) : base(message)
    {
    }

    public CurrentUserNoHomeException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
    public CurrentUserNoHomeException(Guid homeId, Guid userId) : base($"Current user has no home with ID {homeId}.")
    {
        HomeId = homeId;
        UserId = userId;
    }
}