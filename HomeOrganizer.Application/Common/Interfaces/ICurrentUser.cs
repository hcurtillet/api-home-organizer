using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Application.Common.Interfaces;

public interface ICurrentUser
{
    public Guid UserId { get; }
    public string Email { get; }
    public Dictionary<Guid, UserAccountHomeRole> HomeRoles { get; }
}