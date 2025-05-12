using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Events.Home;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace HomeOrganizer.Application.Homes.Commands.RemoveUserAccountToHome;

public class RemoveUserAccountToHomeHandler: IRequestHandler<RemoveUserAccountToHomeRequest>
{
    private readonly IUserAccountHomeDao _userAccountHomeDao;

    public RemoveUserAccountToHomeHandler(IUserAccountHomeDao userAccountHomeDao)
    {
        _userAccountHomeDao = userAccountHomeDao;
    }

    public Task Handle(RemoveUserAccountToHomeRequest request, CancellationToken cancellationToken)
    {
        var userAccountHome = _userAccountHomeDao.GetQueryable(uah => uah.HomeId == request.HomeId && uah.UserAccountId == request.UserAccountId).FirstOrDefault();
        
        if (userAccountHome == null)
        {
            throw new NotFoundException(request.UserAccountId, typeof(UserAccountHome));
        }

        userAccountHome.AddDomainEvent(new UserAccountRemovedEvent(request.HomeId, request.UserAccountId));
        _userAccountHomeDao.Delete(userAccountHome);
        return Task.CompletedTask;
    }
}