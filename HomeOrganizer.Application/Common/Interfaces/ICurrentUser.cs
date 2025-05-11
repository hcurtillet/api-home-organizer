using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.Application.Common.Interfaces;

public interface ICurrentUser
{
    public bool IsAuthenticated { get; }
    public Guid Id { get; }
    public string Email { get; }
    public string Firstname { get; }
    public string Lastname { get; }
    public Dictionary<Guid, UserAccountHomeRole> HomeRoles { get; }

    public void SetCurrentUser(UserAccount userAccount);
}