using HomeOrganizer.Application.Common.Attributes;
using HomeOrganizer.Domain.Enum;
using MediatR;

namespace HomeOrganizer.Application.Homes.Commands.AddUserAccountToHome;

[AuthenticatedHome(UserAccountHomeRole.Owner)]
public class AddUserAccountToHomeRequest: IRequest<AddUserAccountToHomeResponse>
{
    [HomeIdentifier]
    public Guid HomeId { get; }
    public Guid UserAccountId { get; }
    public UserAccountHomeRole Role { get; } = UserAccountHomeRole.Child;
    
    public AddUserAccountToHomeRequest(Guid homeId, Guid userAccountId, UserAccountHomeRole role)
    {
        HomeId = homeId;
        UserAccountId = userAccountId;
        Role = role;
    }
    public AddUserAccountToHomeRequest(Guid homeId, Guid userAccountId)
    {
        HomeId = homeId;
        UserAccountId = userAccountId;
    }
}