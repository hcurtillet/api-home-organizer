using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Enum;
using HomeOrganizer.Domain.Events.Home;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace HomeOrganizer.Application.Homes.EventHandlers;

public class HomeCreatedEventHandler : INotificationHandler<HomeCreatedEvent>
{
    private readonly ICurrentUser _currentUser;
    private readonly IUserAccountHomeDao _userAccountHomeDao;

    public HomeCreatedEventHandler(ICurrentUser currentUser, IUserAccountHomeDao userAccountHomeDao)
    {
        _currentUser = currentUser;
        _userAccountHomeDao = userAccountHomeDao;
    }

    public Task Handle(HomeCreatedEvent notification, CancellationToken cancellationToken)
    {
        var userAccountHome = new UserAccountHome
        {
            HomeId = notification.HomeId,
            UserAccountId = _currentUser.Id,
            Role = UserAccountHomeRole.Owner,
        };
        _userAccountHomeDao.Add(userAccountHome);
        return Task.CompletedTask;
    }
}