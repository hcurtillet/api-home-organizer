using HomeOrganizer.Application.Common.Interfaces.Dao;
using MediatR;

namespace HomeOrganizer.Application.Homes.Commands.AddUserAccountToHome;

public class AddUserAccountToHomeHandler: IRequestHandler<AddUserAccountToHomeRequest, AddUserAccountToHomeResponse>
{
    private readonly IHomeDao _homeDao;
    private readonly IUserAccountHomeDao _userAccountHomeDao;
    private readonly IUserAccountDao _userAccountDao;

    public AddUserAccountToHomeHandler(IUserAccountHomeDao userAccountHomeDao, IHomeDao homeDao, IUserAccountDao userAccountDao)
    {
        _userAccountHomeDao = userAccountHomeDao;
        _homeDao = homeDao;
        _userAccountDao = userAccountDao;
    }

    public Task<AddUserAccountToHomeResponse> Handle(AddUserAccountToHomeRequest request, CancellationToken cancellationToken)
    {
        var home = _homeDao.GetById(request.HomeId);
        if (home == null)
        {
            throw new Exception("Home not found");
        }

        var userAccount = _userAccountDao.GetById(request.UserAccountId);
        if (userAccount == null)
        {
            throw new Exception("User account not found");
        }

        var userAccountHome = new Domain.Entities.UserAccountHome
        {
            HomeId = request.HomeId,
            UserAccountId = request.UserAccountId,
            Role = request.Role
        };
        
        _userAccountHomeDao.Add(userAccountHome);

        return Task.FromResult(new AddUserAccountToHomeResponse(home));
    }
}