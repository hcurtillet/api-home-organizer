using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Events.Task;
using MediatR;

namespace HomeOrganizer.Application.Tasks.EventHandlers;

public class TaskDeleteEventHandler: INotificationHandler<TaskDeleteEvent>
{
    private readonly ITaskUserAccountDao _taskUserAccountDao;

    public TaskDeleteEventHandler(ITaskUserAccountDao taskUserAccountDao)
    {
        _taskUserAccountDao = taskUserAccountDao;
    }

    public Task Handle(TaskDeleteEvent notification, CancellationToken cancellationToken)
    {
        var taskUserAccounts = _taskUserAccountDao.GetQueryable(tua => tua.TaskId == notification.TaskId).ToList();
        if (taskUserAccounts.Count > 0)
        {
            _taskUserAccountDao.DeleteRange(taskUserAccounts);
        }
        return Task.CompletedTask;
    }
}