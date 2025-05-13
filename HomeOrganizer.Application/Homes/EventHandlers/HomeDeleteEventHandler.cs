using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Events.Home;
using HomeOrganizer.Domain.Events.Task;
using MediatR;

namespace HomeOrganizer.Application.Homes.EventHandlers;

public class HomeDeleteEventHandler: INotificationHandler<HomeDeleteEvent>
{
    private readonly ITaskDao _taskDao;
    private readonly IUserAccountHomeDao _userAccountHomeDao;

    public HomeDeleteEventHandler(ITaskDao taskDao, IUserAccountHomeDao userAccountHomeDao)
    {
        _taskDao = taskDao;
        _userAccountHomeDao = userAccountHomeDao;
    }

    public Task Handle(HomeDeleteEvent notification, CancellationToken cancellationToken)
    {
        var tasks = _taskDao.GetQueryable(t => t.HomeId == notification.HomeId).ToList();
        var userAccountHomes = _userAccountHomeDao.GetQueryable(uh => uh.HomeId == notification.HomeId).ToList();
        
        if (tasks.Count > 0)
        {
            tasks.ForEach(t => t.AddDomainEvent(new TaskDeleteEvent(t.Id)));
            _taskDao.DeleteRange(tasks);
        }
        
        if (userAccountHomes.Count > 0)
        {
            _userAccountHomeDao.DeleteRange(userAccountHomes);
        }

        return Task.CompletedTask;
    }
}