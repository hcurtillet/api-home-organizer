using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Application.Homes.Queries.GetCurrentUserHomes;

public class GetCurrentUserHomesResponse
{
    public List<Home> Homes { get; }

    public GetCurrentUserHomesResponse(IEnumerable<Home> homes)
    {
        Homes = homes.ToList();
    }
}