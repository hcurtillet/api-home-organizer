using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Application.Common.Interfaces;

public interface IIdentityService
{
    Guid GetCurrentUserId();
    string? GetCurrentUserEmail();
    UserAccountHomeRole GetCurrentUserRole(string homeId);
    ICurrentUser? GetCurrentUser();
    bool StoreCurrentUser(string email);
}