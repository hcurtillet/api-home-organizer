using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Infrastructure.Dao;

public class UserAccountHomeDao: BaseDao<UserAccountHome>, IUserAccountHomeDao
{
    public UserAccountHomeDao(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}