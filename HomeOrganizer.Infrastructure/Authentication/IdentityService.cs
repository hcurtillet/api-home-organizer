using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Infrastructure.Authentication;

public class IdentityService: IIdentityService 
{
    private CurrentUser? _currentUser = null;
    private readonly IUserAccountDao _userAccountDao;

    public IdentityService(IUserAccountDao userAccountDao)
    {
        _userAccountDao = userAccountDao;
    }

    public Guid GetCurrentUserId()
    {
        if (_currentUser == null)
        {
            throw new NoCurrentUserException(); 
        }

        return _currentUser.UserId;
    }

    public string GetCurrentUserEmail()
    {
        if (_currentUser == null)
        {
            throw new NoCurrentUserException(); 
        }

        return _currentUser.Email;
    }

    public UserAccountHomeRole GetCurrentUserRole(string homeId)
    {
        if (_currentUser == null)
        {
            throw new NoCurrentUserException(); 
        }
        if (!_currentUser.HomeRoles.TryGetValue(Guid.Parse(homeId), out var role))
        {
            throw new CurrentUserNoHomeException(homeId);
        }
        return role;
    }

    public ICurrentUser GetCurrentUser() 
    {
        if (_currentUser == null)
        {
            throw new NoCurrentUserException(); 
        }

        return _currentUser;
    }
    public bool StoreCurrentUser(string email)
    {
        var user = _userAccountDao.GetUserAccountForAuth(email);
        if (user == null)
        {
            return false;
        }

        _currentUser = new CurrentUser(user);
        return true;
    }
}