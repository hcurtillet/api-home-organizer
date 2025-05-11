using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Application.Common.Interfaces;

public interface IIdentityService
{
    Guid GetCurrentUserId();
    string GetCurrentUserEmail();
    UserAccountHomeRole GetCurrentUserRole(Guid homeId);
    ICurrentUser? GetCurrentUser();
    bool StoreCurrentUser(string? email);
    bool IsUserAuthenticated { get; }
}