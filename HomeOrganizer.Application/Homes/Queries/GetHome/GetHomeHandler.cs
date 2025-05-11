using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using MediatR;

namespace HomeOrganizer.Application.Homes.Queries.GetHome;

public class GetHomeHandler: IRequestHandler<GetHomeRequest, GetHomeResponse>
{
    private readonly IIdentityService _identityService;
    private readonly IHomeDao _homeDao;

    public GetHomeHandler(IIdentityService identityService, IHomeDao homeDao)
    {
        _identityService = identityService;
        _homeDao = homeDao;
    }

    public Task<GetHomeResponse> Handle(GetHomeRequest request, CancellationToken cancellationToken)
    {
        _identityService.GetCurrentUserRole(request.Id);
        var home = _homeDao.GetById(request.Id);
        return Task.FromResult(new GetHomeResponse(home));
    }
}