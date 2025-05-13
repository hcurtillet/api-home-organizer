using HomeOrganizer.Domain.Common;

namespace HomeOrganizer.Domain.Events.Task;

public class TaskDeleteEvent: EventBase
{
    public Guid TaskId { get; }
    
    public TaskDeleteEvent (Guid taskId)
    {
        TaskId = taskId;
    }
}