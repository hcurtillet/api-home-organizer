using HomeOrganizer.Application.Common.Interfaces;

namespace HomeOrganizer.Application.UserAccounts.Queries.GetCurrentUser;

public class GetCurrentUserResponse
{
    
    public ICurrentUser CurrentUser { get; }
    
    public GetCurrentUserResponse(ICurrentUser currentUser)
    {
        CurrentUser = currentUser;
    }
}