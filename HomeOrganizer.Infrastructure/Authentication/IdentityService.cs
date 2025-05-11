using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Infrastructure.Authentication;

public class IdentityService: IIdentityService 
{
    private readonly ICurrentUser _currentUser;
    private string? _currentUserEmail = null;
    private readonly IUserAccountDao _userAccountDao;

    public IdentityService(IUserAccountDao userAccountDao, ICurrentUser currentUser)
    {
        _userAccountDao = userAccountDao;
        _currentUser = currentUser;
    }

    public bool IsUserAuthenticated => _currentUser.IsAuthenticated;

    public Guid GetCurrentUserId()
    {
        if (_currentUser.Id == null)
        {
            throw new NoCurrentUserException(); 
        }

        return _currentUser.Id;
    }

    public string GetCurrentUserEmail()
    {
        if (string.IsNullOrEmpty(_currentUserEmail))
        {
            throw new NoCurrentUserEmailException();
        }
        return _currentUserEmail;
    }

    public UserAccountHomeRole GetCurrentUserRole(Guid homeId)
    {
        if (_currentUser == null)
        {
            throw new NoCurrentUserException(); 
        }
        if (!_currentUser.HomeRoles.TryGetValue(homeId, out var role))
        {
            throw new CurrentUserNoHomeException(homeId, _currentUser.Id);
        }
        return role;
    }

    public ICurrentUser GetCurrentUser() 
    {
        if (_currentUser.Email == null)
        {
            throw new NoCurrentUserException(); 
        }

        return _currentUser;
    }
    public bool StoreCurrentUser(string? email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }
        _currentUserEmail = email;
        var user = _userAccountDao.GetUserAccountForAuth(email);
        if (user == null)
        {
            return false;
        }

        _currentUser.SetCurrentUser(user);
        return true;
    }
}