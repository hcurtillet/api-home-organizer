using HomeOrganizer.Application.Common.Interfaces.Dao;
using HomeOrganizer.Domain.Entities;
using MediatR;
using Task = System.Threading.Tasks.Task;

namespace HomeOrganizer.Application.UserAccounts.Commands.CreateUserAccount;

public class CreateUserAccountHandler: IRequestHandler<CreateUserAccountRequest, CreateUserAccountResponse>
{
    private readonly IUserAccountDao _userAccountDao;

    public CreateUserAccountHandler(IUserAccountDao userAccountDao)
    {
        _userAccountDao = userAccountDao;
    }

    public Task<CreateUserAccountResponse> Handle(CreateUserAccountRequest request, CancellationToken cancellationToken)
    {
        
        var userAccount = new UserAccount
        {
            Email = request.Email,
        };
        _userAccountDao.Add(userAccount);
        _userAccountDao.SaveChanges();
        return Task.FromResult(new CreateUserAccountResponse());
    }
}