using MediatR;

namespace HomeOrganizer.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskRequest: IRequest
{
    public Guid TaskId { get; }
    
    public DeleteTaskRequest(Guid taskId)
    {
        TaskId = taskId;
    }
}