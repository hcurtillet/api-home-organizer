using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class AuthenticatedHome: Authenticated
{
    public AuthenticatedHome()
    {
    }
    public AuthenticatedHome(UserAccountHomeRole roles)
    {
        Roles = new List<UserAccountHomeRole> { roles };
    }
    public AuthenticatedHome(UserAccountHomeRole[] roles)
    {
        Roles = roles.ToList();
    }
    public List<UserAccountHomeRole> Roles { get; set; } =
        [UserAccountHomeRole.Adult, UserAccountHomeRole.Child, UserAccountHomeRole.Owner];
}