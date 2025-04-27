using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeOrganizer.Infrastructure.Dao;

public class UserAccountDao : BaseDao<UserAccount>, IUserAccountDao
{
    public UserAccountDao(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public UserAccount? GetUserAccountForAuth(string email) => _repository
        .GetByCondition(u => u.Email == email)
        .Include(u => u.UserAccountHomes)
        .FirstOrDefault();
}