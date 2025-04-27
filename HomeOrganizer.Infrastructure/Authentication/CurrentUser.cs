using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Infrastructure.Authentication;

public class CurrentUser: ICurrentUser
{
    public Guid UserId { get; }
    public string Email { get; }
    public Dictionary<Guid, UserAccountHomeRole> HomeRoles { get; }
    
    public CurrentUser(UserAccount userAccount)
    {
        UserId = userAccount.Id;
        Email = userAccount.Email;
        HomeRoles = userAccount.UserAccountHomes.ToDictionary(x => x.HomeId, x => x.Role);
    }
}