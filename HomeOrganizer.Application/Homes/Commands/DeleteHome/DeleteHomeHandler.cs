using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Events.Home;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace HomeOrganizer.Application.Homes.Commands.DeleteHome;

public class DeleteHomeHandler : IRequestHandler<DeleteHomeRequest>
{
    private readonly IHomeDao _homeDao;

    public DeleteHomeHandler(IHomeDao homeDao)
    {
        _homeDao = homeDao;
    }

    public Task Handle(DeleteHomeRequest request, CancellationToken cancellationToken)
    {
        var home = _homeDao.GetQueryable(h => h.Id == request.Id).FirstOrDefault();

        if (home == null)
        {
            throw new NotFoundException(request.Id, typeof(Home));
        }

        home.AddDomainEvent(new HomeDeleteEvent(home.Id));

        _homeDao.Delete(home);
        return Task.CompletedTask;
    }
}