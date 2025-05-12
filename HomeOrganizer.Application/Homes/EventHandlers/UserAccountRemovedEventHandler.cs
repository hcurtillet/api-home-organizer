using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Events.Home;
using MediatR;

namespace HomeOrganizer.Application.Homes.EventHandlers;

public class UserAccountRemovedEventHandler: INotificationHandler<UserAccountRemovedEvent>
{
    private readonly ITaskUserAccountDao _taskUserAccountDao;

    public UserAccountRemovedEventHandler(ITaskUserAccountDao taskUserAccountDao)
    {
        _taskUserAccountDao = taskUserAccountDao;
    }

    public Task Handle(UserAccountRemovedEvent notification, CancellationToken cancellationToken)
    {
        var taskUserAccounts = _taskUserAccountDao.GetQueryable(tu => tu.UserAccountId == notification.UserAccountId && tu.Task.HomeId == notification.HomeId).ToList();
        
        if (taskUserAccounts.Count > 0)
        {
            _taskUserAccountDao.DeleteRange(taskUserAccounts);
        }

        return Task.CompletedTask;
    }
}