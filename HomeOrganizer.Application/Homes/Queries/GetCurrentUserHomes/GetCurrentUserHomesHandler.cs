using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using MediatR;

namespace HomeOrganizer.Application.Homes.Queries.GetCurrentUserHomes;

public class GetCurrentUserHomesHandler: IRequestHandler<GetCurrentUserHomesRequest, GetCurrentUserHomesResponse>
{
    private readonly ICurrentUser _currentUser;
    private readonly IHomeDao _homeDao;

    public GetCurrentUserHomesHandler(ICurrentUser currentUser, IHomeDao homeDao)
    {
        _currentUser = currentUser;
        _homeDao = homeDao;
    }

    public Task<GetCurrentUserHomesResponse> Handle(GetCurrentUserHomesRequest request, CancellationToken cancellationToken)
    {
        var currentUserHomeIds = _currentUser.HomeRoles.Keys.ToHashSet();
        var homes = _homeDao.GetQueryable(h => currentUserHomeIds.Contains(h.Id));
        return Task.FromResult(new GetCurrentUserHomesResponse(homes));
    }
}