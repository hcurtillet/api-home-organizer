using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Domain.Events.Home;

public class HomeCreatedEvent: EventBase
{
    public Guid HomeId { get; }

    public HomeCreatedEvent(Guid homeId)
    {
        HomeId = homeId;
    }
}