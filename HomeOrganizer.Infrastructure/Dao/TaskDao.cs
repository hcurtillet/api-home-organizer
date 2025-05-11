using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using Task = HomeOrganizer.Domain.Entities.Task;
namespace HomeOrganizer.Infrastructure.Dao;

public class TaskDao: BaseDao<Task>, ITaskDao
{
    public TaskDao(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}