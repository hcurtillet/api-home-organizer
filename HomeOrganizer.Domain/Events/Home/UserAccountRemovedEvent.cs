using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Domain.Events.Home;

public class UserAccountRemovedEvent: EventBase
{
    public Guid HomeId { get; }
    public Guid UserAccountId { get; }
    
    public UserAccountRemovedEvent(Guid homeId, Guid userAccountId)
    {
        HomeId = homeId;
        UserAccountId = userAccountId;
    }
}