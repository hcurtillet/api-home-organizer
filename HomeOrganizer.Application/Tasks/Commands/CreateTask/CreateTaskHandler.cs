using HomeOrganizer.Application.Common.Interfaces.Dao;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskStatus = HomeOrganizer.Domain.Enum.TaskStatus;

namespace HomeOrganizer.Application.Tasks.Commands.CreateTask;

public class CreateTaskHandler: IRequestHandler<CreateTaskRequest, CreateTaskResponse>
{
    private readonly ITaskDao _taskDao;
    private readonly ITaskUserAccountDao _taskUserAccountDao;

    public CreateTaskHandler(ITaskDao taskDao, ITaskUserAccountDao taskUserAccountDao)
    {
        _taskDao = taskDao;
        _taskUserAccountDao = taskUserAccountDao;
    }

    public Task<CreateTaskResponse> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        
        var result = _taskDao.Add(new Domain.Entities.Task
        {
            Description = request.Description,
            HomeId = request.HomeId,
            DueDt = request.DueDt,
            DueTm = request.DueTm,
            TaskStatus = TaskStatus.NotStarted
            
        });
        
        
        var taskUserAccount = request.AssignedToUserAccountIds.Select(userAccountId => new Domain.Entities.TaskUserAccount
        {
            TaskId = result.Id,
            UserAccountId = userAccountId
        }).ToList();
        
        if (taskUserAccount.Count != 0)
        {
            _taskUserAccountDao.AddRange(taskUserAccount);
        }
        
        var task = _taskDao.GetQueryable(t => t.Id == result.Id)
            .Include(t => t.Home)
            .Include(t => t.TaskUserAccounts)
            .ThenInclude(t => t.UserAccount)
            .FirstOrDefault();
        
        return Task.FromResult(new CreateTaskResponse(task));
    }
}