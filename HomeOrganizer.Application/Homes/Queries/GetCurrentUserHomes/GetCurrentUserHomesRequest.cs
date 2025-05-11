using HomeOrganizer.Application.Common.Attributes;
using MediatR;

namespace HomeOrganizer.Application.Homes.Queries.GetCurrentUserHomes;

[Authenticated]
public class GetCurrentUserHomesRequest: IRequest<GetCurrentUserHomesResponse>
{
}