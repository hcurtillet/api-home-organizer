namespace HomeOrganizer.Application.Common.Exceptions;

public class CurrentUserNoHomeException: Exception
{
    private Guid _homeId { get; set; }
    public Guid HomeId => _homeId;
    public CurrentUserNoHomeException() : base("Current user has no home.")
    {
    }

    public CurrentUserNoHomeException(string message) : base(message)
    {
    }

    public CurrentUserNoHomeException(string message, Exception innerException) : base(message, innerException)
    {
    }
    
    public CurrentUserNoHomeException(Guid homeId) : base($"Current user has no home with ID {homeId}.")
    {
        _homeId = homeId;
    }
}