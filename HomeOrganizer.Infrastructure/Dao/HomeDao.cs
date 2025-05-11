using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Infrastructure.Dao;

public class HomeDao: BaseDao<Home>, IHomeDao
{
    public HomeDao(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}