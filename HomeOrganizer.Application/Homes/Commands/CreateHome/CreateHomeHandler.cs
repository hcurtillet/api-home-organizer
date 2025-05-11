using HomeOrganizer.Application.Common.Attributes;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Events.Home;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace HomeOrganizer.Application.Homes.Commands.CreateHome;

public class CreateHomeHandler: IRequestHandler<CreateHomeRequest, CreateHomeResponse>
{
    private readonly IHomeDao _homeDao;

    public CreateHomeHandler(IHomeDao homeDao)
    {
        _homeDao = homeDao;
    }

    public Task<CreateHomeResponse> Handle(CreateHomeRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var newHome = new Home
            {
                Name = request.Name
            };
            newHome.AddDomainEvent(new HomeCreatedEvent(homeId: newHome.Id));
            var result = _homeDao.Add(newHome);

            return Task.FromResult(new CreateHomeResponse(result));
        }
        catch (Exception e)
        {
            throw;
        }
    }
}