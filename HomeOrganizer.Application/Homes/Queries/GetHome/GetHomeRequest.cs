using HomeOrganizer.Application.Common.Attributes;
using MediatR;

namespace HomeOrganizer.Application.Homes.Queries.GetHome;

[AuthenticatedHome]
public class GetHomeRequest: IRequest<GetHomeResponse>
{
    [HomeIdentifier]
    public Guid Id { get; }

    public GetHomeRequest(Guid id)
    {
        Id = id;
    }
}