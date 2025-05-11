using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;

namespace HomeOrganizer.Infrastructure.Dao;

public class TaskUserAccountDao: BaseDao<TaskUserAccount>, ITaskUserAccountDao
{
    public TaskUserAccountDao(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}