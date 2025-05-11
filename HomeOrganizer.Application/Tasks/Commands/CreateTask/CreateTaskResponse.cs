using Task = HomeOrganizer.Domain.Entities.Task;

namespace HomeOrganizer.Application.Tasks.Commands.CreateTask;

public class CreateTaskResponse
{
    public Task Task { get; }
    
    public CreateTaskResponse(Task task)
    {
        Task = task;
    }
}