using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Application.Homes.Commands.CreateHome;

public class CreateHomeResponse
{
    public Home Home { get; }

    public CreateHomeResponse(Home home)
    {
        Home = home;
    }
}