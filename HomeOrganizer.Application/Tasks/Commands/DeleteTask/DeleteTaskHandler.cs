using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Enum;
using HomeOrganizer.Domain.Events.Task;
using MediatR;

namespace HomeOrganizer.Application.Tasks.Commands.DeleteTask;

public class DeleteTaskHandler: IRequestHandler<DeleteTaskRequest>
{
    private readonly ITaskDao _taskDao;
    private readonly IIdentityService _identityService;

    public DeleteTaskHandler(ITaskDao taskDao, IIdentityService identityService)
    {
        _taskDao = taskDao;
        _identityService = identityService;
    }

    public Task Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
    {
        var task = _taskDao.GetQueryable(t => t.Id == request.TaskId).FirstOrDefault();

        if (task == null)
        {
            throw new NotFoundException(request.TaskId, typeof(Domain.Entities.Task));
        }

        var role = _identityService.GetCurrentUserRole(task.HomeId);

        if (role == UserAccountHomeRole.Child)
        {
            throw new UnauthorizedAccessException("A child cannot delete a task");
        }
        
        task.AddDomainEvent(new TaskDeleteEvent(task.Id));

        _taskDao.Delete(task);
        return Task.CompletedTask;
    }
}