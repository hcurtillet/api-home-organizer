using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Application.Common.Interfaces.Dao;

public interface IUserAccountDao: IBaseDao<UserAccount>
{
    public UserAccount? GetUserAccountForAuth(string email);
}