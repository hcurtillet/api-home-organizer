using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Infrastructure.Authentication;

public class CurrentUser: ICurrentUser
{
    public bool IsAuthenticated { get; set; } = false;
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Firstname { get; set; } 
    public string Lastname { get; set; }
    public Dictionary<Guid, UserAccountHomeRole> HomeRoles { get; set; }
    public void SetCurrentUser(UserAccount userAccount)
    {
        var homeRoles = userAccount.UserAccountHomes
            .ToDictionary(x => x.HomeId, x => x.Role);
        Id = userAccount.Id;
        Email = userAccount.Email;
        Firstname = userAccount.Firstname;
        Lastname = userAccount.Lastname;
        HomeRoles = homeRoles;
        IsAuthenticated = true;
    }
}