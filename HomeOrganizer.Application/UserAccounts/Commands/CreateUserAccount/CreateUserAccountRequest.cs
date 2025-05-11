using MediatR;

namespace HomeOrganizer.Application.UserAccounts.Commands.CreateUserAccount;

public class CreateUserAccountRequest: IRequest<CreateUserAccountResponse>
{
    
    public string Email { get; }
    
    public CreateUserAccountRequest(string email)
    {
        Email = email;
    }
}