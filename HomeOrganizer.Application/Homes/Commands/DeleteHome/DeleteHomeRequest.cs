using HomeOrganizer.Application.Common.Attributes;
using HomeOrganizer.Domain.Enum;
using MediatR;

namespace HomeOrganizer.Application.Homes.Commands.DeleteHome;

[AuthenticatedHome(UserAccountHomeRole.Owner)]
public class DeleteHomeRequest: IRequest
{
    [HomeIdentifier]
    public Guid Id { get; }
    
    public DeleteHomeRequest(Guid id)
    {
        Id = id;
    }
}