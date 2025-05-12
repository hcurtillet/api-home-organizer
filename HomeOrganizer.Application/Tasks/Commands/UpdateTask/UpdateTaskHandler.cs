using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace HomeOrganizer.Application.Tasks.Commands.UpdateTask;

public class UpdateTaskHandler: IRequestHandler<UpdateTaskRequest, UpdateTaskResponse>
{
    private readonly IIdentityService _identityService;
    private readonly ITaskDao _taskDao;
    private readonly ITaskUserAccountDao _taskUserAccountDao;

    public UpdateTaskHandler(IIdentityService identityService, ITaskDao taskDao, ITaskUserAccountDao taskUserAccountDao)
    {
        _identityService = identityService;
        _taskDao = taskDao;
        _taskUserAccountDao = taskUserAccountDao;
    }

    public Task<UpdateTaskResponse> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        var task = _taskDao.GetQueryable(t => t.Id == request.Id)
            .Include(t => t.TaskUserAccounts)
            .Include(t => t.Home)
            .ThenInclude(h => h.UserAccountHomes)
            .FirstOrDefault();
        if (task == null)
        {
            throw new NotFoundException(request.Id, typeof(Task));
        }

        var role = _identityService.GetCurrentUserRole(task.HomeId);

        if ((!string.IsNullOrEmpty(request.Description) || !string.IsNullOrEmpty(request.DueTm) ||
             !string.IsNullOrEmpty(request.DueDt) || request.UserAccountIdsToAdd.Count > 0|| request.UserAccountIdsToRemove.Count > 0 ) && role == UserAccountHomeRole.Child)
        {
            throw new UnauthorizedAccessException("A child can only modify the status of the task");
        }

        task.TaskStatus = request.TaskStatus;
        task.Description = request.Description ?? task.Description;
        task.DueDt = request.DueDt ?? task.DueDt;
        task.DueTm = request.DueTm ?? task.DueTm;
        var taskUserAccountToRemove =
            task.TaskUserAccounts.Where(tua => request.UserAccountIdsToRemove.Contains(tua.UserAccountId)).ToList();

        if (taskUserAccountToRemove.Count > 0)
        {
            _taskUserAccountDao.DeleteRange(taskUserAccountToRemove);
        }
        
        request.UserAccountIdsToAdd.ForEach(id =>
        {
            if (task.TaskUserAccounts.All(tua => tua.UserAccountId != id))
            {
                if (task.Home.UserAccountHomes.All(uah => uah.UserAccountId != id))
                {
                    throw new UserNotInHomeException(id, task.HomeId);
                }
                _taskUserAccountDao.Add(new TaskUserAccount
                {
                    TaskId = task.Id,
                    UserAccountId = id
                }, false);
            }
        });

        task = _taskDao.Update(task);

        return Task.FromResult(new UpdateTaskResponse(task));
    }
}