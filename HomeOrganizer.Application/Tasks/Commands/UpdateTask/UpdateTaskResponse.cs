using Task = HomeOrganizer.Domain.Entities.Task;

namespace HomeOrganizer.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskResponse
{
    public Task Task { get; }

    public UpdateTaskResponse(Task task)
    {
        Task = task;
    }
}