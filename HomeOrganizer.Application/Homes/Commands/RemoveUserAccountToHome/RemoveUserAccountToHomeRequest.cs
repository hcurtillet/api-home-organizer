using MediatR;

namespace HomeOrganizer.Application.Homes.Commands.RemoveUserAccountToHome;

public class RemoveUserAccountToHomeRequest: IRequest
{
    public Guid HomeId { get; }
    public Guid UserAccountId { get; }
    
    public RemoveUserAccountToHomeRequest(Guid homeId, Guid userAccountId)
    {
        HomeId = homeId;
        UserAccountId = userAccountId;
    }
}