using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Application.Homes.Queries.GetHome;

public class GetHomeResponse
{
    public Home Home { get; }

    public GetHomeResponse(Home home)
    {
        Home = home;
    }
}