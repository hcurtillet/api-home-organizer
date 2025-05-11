namespace HomeOrganizer.Application.Common.Exceptions;

public class UserNotInHomeException: Exception
{
    public UserNotInHomeException(Guid userAccountId, Guid homeId): base($"The user {userAccountId} is not in the home {homeId}"){}
}