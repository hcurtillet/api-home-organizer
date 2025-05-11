using MediatR;
using TaskStatus = HomeOrganizer.Domain.Enum.TaskStatus;

namespace HomeOrganizer.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskRequest : IRequest<UpdateTaskResponse>
{
    public Guid Id { get; }
    public string? Description { get; }
    public string? DueDt { get; }
    public string? DueTm { get; }
    public TaskStatus TaskStatus { get; }
    public List<Guid> UserAccountIdsToAdd { get; set; }
    public List<Guid> UserAccountIdsToRemove { get; }

    public UpdateTaskRequest(Guid id, string? description, string? dueDt, string? dueTm, TaskStatus taskStatus,
        List<Guid>? userAccountIdsToAdd, List<Guid>? userAccountIdsToRemove)
    {
        Id = id;
        Description = description;
        DueDt = dueDt;
        DueTm = dueTm;
        TaskStatus = taskStatus;
        UserAccountIdsToAdd = userAccountIdsToAdd ?? [];
        UserAccountIdsToRemove = userAccountIdsToRemove ?? [];
    }
}