using HomeOrganizer.Application.Common.Attributes;
using HomeOrganizer.Domain.Enum;
using MediatR;

namespace HomeOrganizer.Application.Tasks.Commands.CreateTask;

[AuthenticatedHome([UserAccountHomeRole.Adult, UserAccountHomeRole.Owner])]
public class CreateTaskRequest : IRequest<CreateTaskResponse>
{
    [HomeIdentifier] public Guid HomeId { get; }
    public string Description { get; }
    public string? DueDt { get; }
    public string? DueTm { get; }
    public List<Guid> AssignedToUserAccountIds { get; }

    public CreateTaskRequest(Guid homeId, string description, string? dueDt, string? dueTm,
        List<Guid>? assignedToUserAccountIds)
    {
        HomeId = homeId;
        Description = description;
        DueDt = dueDt;
        DueTm = dueTm;
        AssignedToUserAccountIds = assignedToUserAccountIds ?? [];
    }
}   