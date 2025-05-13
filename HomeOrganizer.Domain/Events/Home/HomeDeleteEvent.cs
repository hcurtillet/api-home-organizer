using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Domain.Events.Home;

public class HomeDeleteEvent: EventBase
{
    public HomeDeleteEvent(Guid homeId)
    {
        HomeId = homeId;
    }

    public Guid HomeId { get; }
}